using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class AiRecordDisplayViewModel
{
    public AiRecord Record { get; set; }
    public bool AllowEdit { get; set; }

    // public FoodRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<FoodRecord> records)
    public AiRecordDisplayViewModel(bool allowEdit, AiRecord record)
    {
        AllowEdit = allowEdit;
        Record = record;
    }
}