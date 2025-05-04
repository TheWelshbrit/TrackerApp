using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class FoodRecordsDisplayViewModel
{
    public List<FoodRecord> FoodRecords { get; set; }
    //public string FoodRecordsDisplayTitle { get; set; }
    // public string AddEditFoodEndpoint { get; set; }
    // public string AddEditFoodModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public FoodRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<FoodRecord> records)
    public FoodRecordsDisplayViewModel(bool allowEdit, List<FoodRecord> records)
    {
        // FoodRecordsDisplayTitle = displayTitle;
        // AddEditFoodEndpoint = endpoint;
        // AddEditFoodModalTitle = modalTitle;
        AllowEdit = allowEdit;
        FoodRecords = records;
    }
}