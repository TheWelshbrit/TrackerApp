using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tracker.Web.Models;
using Tracker.Core;
using Tracker.Core.Models;
using Tracker.Core.Interfaces;
using Tracker.Web.ViewModels.Home;


namespace Tracker.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDayRecordRepository _repo;

    public HomeController(ILogger<HomeController> logger, IDayRecordRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new IndexViewModel
        {
            DayRecords = _repo.GetAllRecords(),
            DayInProgress = _repo.GetDayInProgress()
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpGet]
    public IActionResult CompleteDayInProgress()
    {
        _repo.AddRecord(_repo.GetDayInProgress());

        var newDay = new DayRecord() {RecordDate = DateOnly.FromDateTime(DateTime.Now)};
        _repo.UpdateDayInProgress(newDay);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateDayInProgressDate(DateOnly recordDate)
    {
        var current = _repo.GetDayInProgress();
        current.RecordDate = recordDate;
        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

#region Day In Progress - Add



    [HttpPost]
    public IActionResult AddMoodNote(string noteText, string noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.MoodNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = ParseTime(noteTime)
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult AddToothBrushingActivity(string noteText, string noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.TeethCleaningInstances.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = ParseTime(noteTime)
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

        
    [HttpPost]
    public IActionResult AddHygeineNote(string noteText, string noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.HygeineNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = ParseTime(noteTime)
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddContextNote(string noteText, string noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.ContextNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = ParseTime(noteTime)
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddSleepRecord(string sleepType, string start, string end, decimal duration, string note)
    {
        var current = _repo.GetDayInProgress();

        Enum.TryParse(sleepType, out SleepingType sleepTypeEnum);

        current.SleepRecords.Add(new SleepRecord
        {
            SleepType = sleepTypeEnum,
            SleepAttemptStartTime = ParseTime(start),
            SleepAttemptEndTime = ParseTime(end),
            EstimatedActualSleepDuration = duration,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult AddFoodRecord(string foodType, string food, string time, string note)
    {
        var current = _repo.GetDayInProgress();

        Enum.TryParse(foodType, out FoodConsumptionType foodTypeEnum);

        current.FoodRecords.Add(new FoodRecord
        {
            FoodType = foodTypeEnum,
            Food = food,
            TimeStartedEating = ParseTime(time),
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddDrinkRecord(string drink, string time, decimal quantity, string quantityMeasurement, bool alcoholic, decimal alcoholPercentage, string note)
    {
        var current = _repo.GetDayInProgress();

        current.DrinkRecords.Add(new DrinkRecord
        {
            TimeStartedDrinking = ParseTime(time),
            Drink = drink,
            Quantity = quantity,
            QuantityMeasurement = quantityMeasurement,
            Alcoholic = alcoholic,
            AlcoholPercentage = alcoholPercentage,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddShowerActivity(string start, string end, bool shavedBody, bool shavedFace, string note)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.ShowerInstances.Add(new ShowerActivity
        {
            StartTime = ParseTime(start),
            EndTime = ParseTime(end),
            ShavedBody = shavedBody,
            ShavedFace = shavedFace,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddGamingActivity(string start, string end, string game, string people, string note)
    {
        var current = _repo.GetDayInProgress();
        var peopleList = (people == string.Empty) ? new List<string>() 
                        : people.Split(",").Select(person => person.Trim()).ToList();

        current.GamingSessions.Add(new GamingRecord
        {
            StartTime = ParseTime(start),
            EndTime = ParseTime(end),
            Game = game,
            PeoplePlayedWith = peopleList,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddExcerciseActivity(string type, string activity, string start, string end, string note)
    {
        var current = _repo.GetDayInProgress();

        current.ExerciseSessions.Add(new ExcerciseRecord
        {
            StartTime = ParseTime(start),
            EndTime = ParseTime(end),
            Activity = activity,
            Type = type,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }


    

    #region Add GenericActivity items
    [HttpPost]
    public IActionResult AddWorkActivity(string activityText, string startTime, string endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.WorkDayRecord.WorkActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddPianoActivity(string activityText, string startTime, string endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.PianoRecords.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddChoreActivity(string activityText, string startTime, string endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.ChoreActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddGptChatActivity(string activityText, string startTime, string endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.GptChatActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddOtherActivity(string activityText, string startTime, string endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.OtherActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    #endregion
    #endregion



    private DateTime ParseTime(string timeString)
    {
        return string.IsNullOrEmpty(timeString)
                    ? DateTime.Now
                    : DateTime.Today.Add(TimeSpan.Parse(timeString));
    }
    private GenericActivity NewGenericActivity(string activityText, string startTime, string endTime, string note)
    {
        return new GenericActivity
        {
            Activity = activityText,
            StartTime = ParseTime(startTime),
            EndTime = ParseTime(endTime),
            Note = note
        };
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
