using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class GenericActivityRecordsDisplayViewModel
{
    public List<GenericActivity> GenericActivityRecords { get; set; }
    public string GenericActivityRecordsDisplayTitle { get; set; }

    public string GenericActivityRecordsDisplayTitleDomTag { get; set; }
    public string AddEditGenericActivityEndpoint { get; set; }
    public string AddEditGenericActivityModalTitle { get; set; }
    public string AddGenericActivityButtonLabel { get; set; }
    public bool AllowEdit { get; set; }

    public GenericActivityRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<GenericActivity> records, string titleDomTag = "h4", string addButtonLabel = "+")
    {
        GenericActivityRecordsDisplayTitle = displayTitle;
        AddEditGenericActivityEndpoint = endpoint;
        AddEditGenericActivityModalTitle = modalTitle;
        AddGenericActivityButtonLabel = addButtonLabel;
        AllowEdit = allowEdit;
        GenericActivityRecords = records;
        GenericActivityRecordsDisplayTitleDomTag = titleDomTag;
    }
}