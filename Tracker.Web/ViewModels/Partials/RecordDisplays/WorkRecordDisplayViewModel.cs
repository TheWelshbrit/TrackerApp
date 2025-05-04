using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class WorkRecordDisplayViewModel
{
    public WorkDayRecord WorkRecord { get; set; }
    //public string WorkRecordsDisplayTitle { get; set; }
    // public string AddEditWorkEndpoint { get; set; }
    // public string AddEditWorkModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public WorkRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<WorkRecord> records)
    public WorkRecordDisplayViewModel(bool allowEdit, WorkDayRecord record)
    {
        // WorkRecordsDisplayTitle = displayTitle;
        // AddEditWorkEndpoint = endpoint;
        // AddEditWorkModalTitle = modalTitle;
        AllowEdit = allowEdit;
        WorkRecord = record;
    }
}