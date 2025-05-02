using Tracker.Core.Models;

namespace Tracker.Web.ViewModels.Home;

public class IndexViewModel
{
    public List<DayRecord> DayRecords { get; set; }
    public DayRecord DayInProgress { get; set; }
}