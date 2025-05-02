namespace Tracker.Web.ViewModels.Partials.Forms.InputFields;

public class AddOrCloseButtonsViewModel
{
    public string ModalId { get; set; }
    public string AddButtonLabel { get; set; }
    public string CloseButtonLabel { get; set; }

    public AddOrCloseButtonsViewModel(string modalId, string? addButtonLabel = null, string? closeButtonLabel = null)
    {
        ModalId = modalId;
        AddButtonLabel = addButtonLabel ?? "Add";
        CloseButtonLabel = closeButtonLabel ?? "Cancel";
    }
}