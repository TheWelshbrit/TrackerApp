using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class InstanceRecordsDisplayViewModel
{
    public List<InstanceRecord> GenericInstanceRecords { get; set; }
    public string GenericInstanceRecordsDisplayTitle { get; set; }

    public string GenericInstanceRecordsDisplayTitleDomTag { get; set; }
    public string AddEditGenericInstanceEndpoint { get; set; }
    public string AddEditGenericInstanceModalTitle { get; set; }
    public string AddGenericInstanceButtonLabel { get; set; }
    public bool AllowEdit { get; set; }

    public InstanceRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<InstanceRecord> records, string titleDomTag = "h4", string addButtonLabel = "+")
    {
        GenericInstanceRecordsDisplayTitle = displayTitle;
        AddEditGenericInstanceEndpoint = endpoint;
        AddEditGenericInstanceModalTitle = modalTitle;
        AddGenericInstanceButtonLabel = addButtonLabel;
        AllowEdit = allowEdit;
        GenericInstanceRecords = records;
        GenericInstanceRecordsDisplayTitleDomTag = titleDomTag;
    }
}