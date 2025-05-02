using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials;

public class DayRecordDisplayViewModel
{
    public DayRecord Record { get; set; }
    public bool AllowEdit { get; set; }
    public bool IncludeEditDayButton { get; set; }

    public DayRecordDisplayViewModel(DayRecord record, bool allowEdit, bool includeEditDayButton)
    {
        Record = record;
        AllowEdit = allowEdit;
        IncludeEditDayButton = includeEditDayButton;
    } 
}