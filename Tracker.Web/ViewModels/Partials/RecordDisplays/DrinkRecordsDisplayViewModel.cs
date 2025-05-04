using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class DrinkRecordsDisplayViewModel
{
    public List<DrinkRecord> DrinkRecords { get; set; }
    //public string DrinkRecordsDisplayTitle { get; set; }
    // public string AddEditDrinkEndpoint { get; set; }
    // public string AddEditDrinkModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public DrinkRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<DrinkRecord> records)
    public DrinkRecordsDisplayViewModel(bool allowEdit, List<DrinkRecord> records)
    {
        // DrinkRecordsDisplayTitle = displayTitle;
        // AddEditDrinkEndpoint = endpoint;
        // AddEditDrinkModalTitle = modalTitle;
        AllowEdit = allowEdit;
        DrinkRecords = records;
    }
}