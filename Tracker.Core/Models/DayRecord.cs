using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace Tracker.Core.Models;

public class DayRecord
{
    public DateOnly RecordDate { get; set; }
    public List<NoteRecord> MoodNotes { get; set; } = new List<NoteRecord>();
    public List<NoteRecord> ContextNotes { get; set; } = new List<NoteRecord>();
    public AiRecord AiDailyOverview { get; set; } = new AiRecord();
    public List<SleepRecord> SleepRecords { get; set; } = new List<SleepRecord>();
    public HygeineRecord Hygeine { get; set; } = new HygeineRecord();
    public List<FoodRecord> FoodRecords { get; set; } = new List<FoodRecord>();
    public List<DrinkRecord> DrinkRecords { get; set; } = new List<DrinkRecord>();
    public WorkDayRecord WorkDayRecord { get; set; } = new WorkDayRecord();
    public List<ExcerciseRecord> ExerciseSessions { get; set; } = new List<ExcerciseRecord>();
    public List<GamingRecord> GamingSessions { get; set; } = new List<GamingRecord>();
    public List<GenericActivity> PianoRecords { get; set; } = new List<GenericActivity>();
    public List<GenericActivity> ChoreActivities { get; set; } = new List<GenericActivity>();
    public List<GenericActivity> GptChatActivities { get; set; } = new List<GenericActivity>();
    public List<GenericActivity> OtherActivities { get; set; } = new List<GenericActivity>();
}
public class AiRecord
{
    public DateTime TimeAiContributionGenerated { get; set; }
    public string AiQuote { get; set; } = string.Empty;
    public string AiNote { get; set; } = string.Empty;
}
public class SleepRecord
{
    public SleepingType SleepType { get; set; }
    public DateTime SleepAttemptStartTime { get; set; }
    public DateTime SleepAttemptEndTime { get; set; }
    public decimal EstimatedActualSleepDuration { get; set; }
    public string? Note { get; set; }
}
public enum SleepingType
{
    Sleep,
    Nap
}
public class HygeineRecord
{
    public List<ShowerActivity> ShowerInstances { get; set; }= new List<ShowerActivity>();
    public List<NoteRecord> TeethCleaningInstances { get; set; } = new List<NoteRecord>();
    public List<NoteRecord> HygeineNotes { get; set; } = new List<NoteRecord>();
}
public class FoodRecord
{
    public FoodConsumptionType FoodType { get; set; }
    public string Food { get; set; } = string.Empty;
    public DateTime? TimeStartedEating { get; set; }
    public string? Note { get; set; }
}
public enum FoodConsumptionType
{
    Breakfast,
    Lunch,
    Tea,
    Snack
}
public class DrinkRecord
{
    public DateTime? TimeStartedDrinking { get; set; }
    public string Drink { get; set; }
    public decimal Quantity { get; set; }
    public string QuantityMeasurement { get; set;} = string.Empty;
    public bool Alcoholic { get; set; }
    public decimal? AlcoholPercentage { get; set; }
    public string? Note { get; set; }
}
public class ShowerActivity
{
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool ShavedBody { get; set; }
    public bool ShavedFace { get; set; }
    public string Note { get; set; }
}
public class WorkDayRecord
{
    public string Location { get; set; } = string.Empty;
    public decimal TotalHours { get; set; }
    public List<NoteRecord> OverallNotes { get; set; } = new List<NoteRecord>();
    public List<GenericActivity> WorkActivities { get; set; } = new List<GenericActivity>();
}


public class ExcerciseRecord
{
    public string Type { get; set; }
    public string Activity { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Note { get; set; } = string.Empty;
}


public class GamingRecord
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Game { get; set; }  = string.Empty;
    public List<string> PeoplePlayedWith { get; set; } = new List<string>();
    public string? Note { get; set; }
}
public class GenericActivity 
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Activity { get; set; }  = string.Empty;
    public string? Note { get; set; }
}
public class NoteRecord
{
    public DateTime? TimeNoteMade { get; set; }
    public string Note { get; set; } = string.Empty;
}
