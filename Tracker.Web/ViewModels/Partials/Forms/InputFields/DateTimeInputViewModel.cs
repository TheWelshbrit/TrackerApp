using Tracker.Core.Models;
using Tracker.Web.Extensions;
namespace Tracker.Web.ViewModels.Partials.Forms.InputFields;

public class DateTimeInputViewModel
{
    public bool IncludeEndTime { get; set; }
    public string StartTimeName { get; set; }
    public string EndTimeName { get; set; }
    public string StartTimeLabel { get; set; }
    public string EndTimeLabel { get; set; }
    public string StartTimeValue { get; set; }
    public string EndTimeValue { get; set; }

    public DateTimeInputViewModel(string startname, string startLabel, string endTime, string endLabel, DateTime presetValue)
    {
        var formattedPresetValue = presetValue.FormatForDatePicker();
        IncludeEndTime = true;
        StartTimeName = startname;
        StartTimeLabel = startLabel;
        EndTimeName = endTime;
        EndTimeLabel = endLabel;
        StartTimeValue = formattedPresetValue; 
        EndTimeValue = formattedPresetValue;
    }
    public DateTimeInputViewModel(string startname, string startLabel, string endTime, string endLabel, DateTime? presetStartValue = null, DateTime? presetEndValue = null)
    {
        presetStartValue = presetStartValue ?? DateTime.Now;
        presetEndValue = presetEndValue ?? presetStartValue;

        IncludeEndTime = true;
        StartTimeName = startname;
        StartTimeLabel = startLabel;
        EndTimeName = endTime;
        EndTimeLabel = endLabel;
        StartTimeValue = presetStartValue.FormatForDatePicker();
        EndTimeValue = presetEndValue.FormatForDatePicker();
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public DateTimeInputViewModel(string startname, string startLabel, DateTime? presetStartValue = null)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        presetStartValue = presetStartValue ?? DateTime.Now;
        IncludeEndTime = false;
        StartTimeName = startname;
        StartTimeLabel = startLabel;
        StartTimeValue = presetStartValue.FormatForDatePicker();
    }
}