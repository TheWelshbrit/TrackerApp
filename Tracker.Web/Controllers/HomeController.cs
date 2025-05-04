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
    public IActionResult AddMoodNote(string noteText, DateTime noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.MoodNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = noteTime
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult AddToothBrushingActivity(string genericInstanceNoteText, DateTime startGenericInstanceTime, DateTime endGenericInstanceTime)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.TeethCleaningInstances.Add(new InstanceRecord
        {
            TimeStarted = startGenericInstanceTime,
            TimeEnded = endGenericInstanceTime,
            Note = genericInstanceNoteText
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult UpdateAiRecord(string note, string quote)
    {
        var current = _repo.GetDayInProgress();

        current.AiDailyOverview.AiQuote = quote;
        current.AiDailyOverview.AiNote = note;
        current.AiDailyOverview.TimeAiContributionGenerated = DateTime.Now;
        
        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateWorkLocationAndHours(string workLocation, decimal workHours, string overrideHours)
    {
        var current = _repo.GetDayInProgress();

        current.WorkDayRecord.Location = workLocation;
        if (overrideHours == "on")
        {
            current.WorkDayRecord.HoursOverridden = true;
            current.WorkDayRecord.TotalHours = workHours;
        }
        else
        {
            current.WorkDayRecord.HoursOverridden = false;
            current.WorkDayRecord.TotalHours = (decimal)current.WorkDayRecord.WorkActivities.Sum(activity => (activity.EndTime - activity.StartTime).TotalHours);
        }
        
        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
        
    [HttpPost]
    public IActionResult AddHygeineNote(string noteText, DateTime noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.HygeineNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = noteTime
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddContextNote(string noteText, DateTime noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.ContextNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = noteTime
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddWorkNote(string noteText, DateTime noteTime)
    {
        var current = _repo.GetDayInProgress();

        current.WorkDayRecord.OverallNotes.Add(new NoteRecord
        {
            Note = noteText,
            TimeNoteMade = noteTime
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddSleepRecord(string sleepType, DateTime start, DateTime end, decimal duration, string note)
    {
        var current = _repo.GetDayInProgress();

        Enum.TryParse(sleepType, out SleepingType sleepTypeEnum);

        current.SleepRecords.Add(new SleepRecord
        {
            SleepType = sleepTypeEnum,
            SleepAttemptStartTime = start,
            SleepAttemptEndTime = end,
            EstimatedActualSleepDuration = duration,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult AddFoodRecord(string foodType, string food, DateTime timeStartedEating, DateTime timeFinishedEating, string note)
    {
        var current = _repo.GetDayInProgress();

        Enum.TryParse(foodType, out FoodConsumptionType foodTypeEnum);

        current.FoodRecords.Add(new FoodRecord
        {
            FoodType = foodTypeEnum,
            Food = food,
            TimeStartedEating = timeStartedEating,
            TimeFinishedEating = timeFinishedEating,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddDrinkRecord(string drink, DateTime timeStartedDrinking, decimal quantity, string quantityMeasurement, string alcoholic, decimal alcoholPercentage, string note)
    {
        var current = _repo.GetDayInProgress();

        current.DrinkRecords.Add(new DrinkRecord
        {
            TimeStartedDrinking = timeStartedDrinking,
            Drink = drink,
            Quantity = quantity,
            QuantityMeasurement = quantityMeasurement,
            Alcoholic = (alcoholic == "on"),
            AlcoholPercentage = alcoholPercentage,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddShowerActivity(DateTime startShowerTime, DateTime endShowerTime, string shavedBody, string shavedFace, string note)
    {
        var current = _repo.GetDayInProgress();

        current.Hygeine.ShowerInstances.Add(new ShowerActivity
        {
            StartTime = startShowerTime,
            EndTime = endShowerTime,
            ShavedBody = (shavedBody == "on"),
            ShavedFace = (shavedFace == "on"),
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddGamingActivity(DateTime startGameTime, DateTime endGameTime, string game, string people, string note)
    {
        var current = _repo.GetDayInProgress();
        var peopleList = (people == string.Empty) ? new List<string>() 
                        : people.Split(",").Select(person => person.Trim()).ToList();

        current.GamingSessions.Add(new GamingRecord
        {
            StartTime = startGameTime,
            EndTime = endGameTime,
            Game = game,
            PeoplePlayedWith = peopleList,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddExcerciseActivity(string type, string activity, DateTime startExcerciseTime, DateTime endExcerciseTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.ExerciseSessions.Add(new ExerciseRecord
        {
            StartTime = startExcerciseTime,
            EndTime = endExcerciseTime,
            Activity = activity,
            Type = type,
            Note = note
        });

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }


    

    #region Add GenericActivity items
    [HttpPost]
    public IActionResult AddWorkActivity(string activityText, DateTime startTime, DateTime endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.WorkDayRecord.WorkActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        if(!current.WorkDayRecord.HoursOverridden)
        {
            current.WorkDayRecord.TotalHours = (decimal)current.WorkDayRecord.WorkActivities.Sum(activity => (activity.EndTime - activity.StartTime).TotalHours);
        }

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddPianoActivity(string activityText, DateTime startTime, DateTime endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.PianoRecords.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddChoreActivity(string activityText, DateTime startTime, DateTime endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.ChoreActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddGptChatActivity(string activityText, DateTime startTime, DateTime endTime, string note)
    {
        var current = _repo.GetDayInProgress();

        current.GptChatActivities.Add(NewGenericActivity(activityText, startTime, endTime, note));

        _repo.UpdateDayInProgress(current);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddOtherActivity(string activityText, DateTime startTime, DateTime endTime, string note)
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
    private GenericActivity NewGenericActivity(string activityText, DateTime startTime, DateTime endTime, string note)
    {
        return new GenericActivity
        {
            Activity = activityText,
            StartTime = startTime,
            EndTime = endTime,
            Note = note
        };
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
