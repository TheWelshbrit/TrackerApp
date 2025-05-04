using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class NoteRecordsDisplayViewModel
{
    public List<NoteRecord> NoteRecords { get; set; }
    public string NoteRecordsDisplayTitle { get; set; }

    public string NoteRecordsDisplayTitleDomTag { get; set; }
    public string AddEditNoteEndpoint { get; set; }
    public string AddEditNoteModalTitle { get; set; }
    public string AddNoteButtonLabel { get; set; }
    public bool AllowEdit { get; set; }

    public NoteRecordsDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, List<NoteRecord> records, string titleDomTag = "h4", string addButtonLabel = "+")
    {
        NoteRecordsDisplayTitle = displayTitle;
        AddEditNoteEndpoint = endpoint;
        AddEditNoteModalTitle = modalTitle;
        AddNoteButtonLabel = addButtonLabel;
        AllowEdit = allowEdit;
        NoteRecords = records;
        NoteRecordsDisplayTitleDomTag = titleDomTag;
    }
}