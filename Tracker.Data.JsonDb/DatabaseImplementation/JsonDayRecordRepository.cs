using Tracker.Core.Interfaces;
using Tracker.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Tracker.Data.JsonDb.DatabaseImplementation;

public class JsonDayRecordRepository : IDayRecordRepository
{
    private readonly string _daysFilePath = "days.json";
    private readonly string _dayInProgressFilePath = "dayInProgress.json";
    private List<DayRecord> _records = new();
    private DayRecord _dayInProgress = new();

    public JsonDayRecordRepository()
    {
        if (File.Exists(_daysFilePath))
        {
            var json = File.ReadAllText(_daysFilePath);
            _records = JsonSerializer.Deserialize<List<DayRecord>>(json, GetJsonSerializerOptions()) ?? new();
        }
        if (File.Exists(_dayInProgressFilePath))
        {
            var json = File.ReadAllText(_dayInProgressFilePath);
            _dayInProgress = JsonSerializer.Deserialize<DayRecord>(json, GetJsonSerializerOptions()) ?? new();
        }
    }

    public List<DayRecord> GetAllRecords() => _records;
    public DayRecord GetDayInProgress() => _dayInProgress;


    public void AddRecord(DayRecord day)
    {
        _records.Add(day);
        SaveDays();
    }

    public void SaveDays()
    {
        var json = JsonSerializer.Serialize(_records, GetJsonSerializerOptions());
        File.WriteAllText(_daysFilePath, json);
    }

    public void UpdateDayInProgress(DayRecord updatedRecord)
    {
        var json = JsonSerializer.Serialize(updatedRecord, GetJsonSerializerOptions());
        File.WriteAllText(_dayInProgressFilePath, json);
    }


    private JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }
}
