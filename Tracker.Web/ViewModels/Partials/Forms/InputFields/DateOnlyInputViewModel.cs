namespace Tracker.Web.ViewModels.Partials.Forms.InputFields;

public class DateOnlyInputViewModel : GenericInputViewModel
{
    public string DateValue { get; set; }

    public DateOnlyInputViewModel(string name, string label, DateOnly? presetValue = null) : base(name, label)
    {
        DateValue = (presetValue ?? DateOnly.FromDateTime(DateTime.Now)).ToString("yyy-MM-dd");
    }
}