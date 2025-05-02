namespace Tracker.Web.ViewModels.Partials.Forms.InputFields;

public class OptionSetPickerViewModel : GenericInputViewModel
{
    public List<string> Options { get; set; } = new List<string>();

    public OptionSetPickerViewModel(string name, string label, IEnumerable<string> options) : base(name, label)
    {
        Options = options.OrderBy(o => o).ToList();
    }
}