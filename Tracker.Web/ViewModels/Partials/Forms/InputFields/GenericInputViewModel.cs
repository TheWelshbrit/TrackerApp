namespace Tracker.Web.ViewModels.Partials.Forms.InputFields;

public class GenericInputViewModel
{
    public string InputName { get; set; } = string.Empty;
    public string InputLabel { get; set; } = string.Empty;

    public GenericInputViewModel(string name, string label)
    {
        InputName = name;
        InputLabel = label;
    }
}