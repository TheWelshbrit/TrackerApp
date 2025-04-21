using Tracker.Core.Models;

namespace Tracker.Core.Interfaces;

public interface IDayRecordRepository
{
    List<DayRecord> GetAllRecords();
    void AddRecord(DayRecord record);
    void Save();
}