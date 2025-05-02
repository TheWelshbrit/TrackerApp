namespace Tracker.Web.Extensions;

public static class DateTimeExtensions
{
    public static string FormatForDatePicker(this DateTime? d)
    {
        return (d == null)
            ? string.Empty 
            : ((DateTime)d).FormatForDatePicker();
    }
    public static string FormatForDatePicker(this DateTime d)
    {
        return d.ToString("yyyy-MM-ddTHH:mm");
    }

}