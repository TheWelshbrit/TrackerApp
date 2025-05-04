using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Partials.RecordDisplays;

public class HygeineRecordDisplayViewModel
{
    public HygeineRecord Record { get; set; }
    // public string NoteRecordsDisplayTitle { get; set; }
    // public string AddEditNoteEndpoint { get; set; }
    // public string AddEditNoteModalTitle { get; set; }
    public bool AllowEdit { get; set; }

    // public HygeineRecordDisplayViewModel(string displayTitle, string endpoint, string modalTitle, bool allowEdit, HygeineRecord record)
    public HygeineRecordDisplayViewModel(bool allowEdit, HygeineRecord record)
    {
        // NoteRecordsDisplayTitle = displayTitle;
        // AddEditNoteEndpoint = endpoint;
        // AddEditNoteModalTitle = modalTitle;
        AllowEdit = allowEdit;
        Record = record;
    }
}