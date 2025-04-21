using Tracker.Core.Interfaces;
using Tracker.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tracker.Data.JsonDb.DatabaseImplementation;

public class JsonDayRecordRepository : IDayRecordRepository
{
    private readonly string _filePath = "days.json";
    private List<DayRecord> _records = new();

    public JsonDayRecordRepository()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _records = JsonSerializer.Deserialize<List<DayRecord>>(json, GetJsonSerializerOptions()) ?? new();
        }
    }

    public List<DayRecord> GetAllRecords() => _records;

    public void AddRecord(DayRecord day)
    {
        _records.Add(day);
        Save();
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(_records, GetJsonSerializerOptions());
        File.WriteAllText(_filePath, json);
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
