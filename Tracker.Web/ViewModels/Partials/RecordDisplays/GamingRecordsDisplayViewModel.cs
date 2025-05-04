using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class GamingRecordsDisplayViewModel
{
    public List<GamingRecord> GamingRecords { get; set; }
    //public string DrinkRecordsDisplayTitle { get; set; }
    // public string AddEditDrinkEndpoint { get; set; }
    // public string AddEditDrinkModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public DrinkRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<DrinkRecord> records)
    public GamingRecordsDisplayViewModel(bool allowEdit, List<GamingRecord> records)
    {
        // DrinkRecordsDisplayTitle = displayTitle;
        // AddEditDrinkEndpoint = endpoint;
        // AddEditDrinkModalTitle = modalTitle;
        AllowEdit = allowEdit;
        GamingRecords = records;
    }
}