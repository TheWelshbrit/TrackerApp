using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class SleepRecordsDisplayViewModel
{
    public List<SleepRecord> SleepRecords { get; set; }
    //public string SleepRecordsDisplayTitle { get; set; }
    // public string AddEditSleepEndpoint { get; set; }
    // public string AddEditSleepModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public SleepRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<SleepRecord> records)
    public SleepRecordsDisplayViewModel(bool allowEdit, List<SleepRecord> records)
    {
        // SleepRecordsDisplayTitle = displayTitle;
        // AddEditSleepEndpoint = endpoint;
        // AddEditSleepModalTitle = modalTitle;
        AllowEdit = allowEdit;
        SleepRecords = records;
    }
}