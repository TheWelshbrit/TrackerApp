using Tracker.Core.Models;

namespace Tracker.Web.Models;

public static class ExtensionMethods
{
    public static string GenerateDisplayString(this ShowerActivity i)
    {
        var dateTimesString = $"{i.StartTime?.ToShortTimeString()} => {i.EndTime?.ToShortTimeString()}";
        var shavedString = (i.ShavedBody && i.ShavedFace) ? " - Shaved: Body + Face"
                            : (i.ShavedBody) ? " - Shaved: Body"
                                : (i.ShavedFace) ? " - Shaved: Face"
                                    :" - Shaved: None";
        var noteString = (String.IsNullOrEmpty(i.Note)) ? String.Empty
                        : $" - <em>{i.Note}</em>";

        return dateTimesString + shavedString + noteString;                        
    }
    public static string GenerateDisplayString(this InstanceRecord i)
    {
        var dateTimesString = $"{i.TimeStarted?.ToShortTimeString()} => {i.TimeEnded?.ToShortTimeString()}";
        var noteString = (String.IsNullOrEmpty(i.Note)) ? String.Empty
                        : $" - <em>{i.Note}</em>";

        return dateTimesString + noteString;                        
    }
}