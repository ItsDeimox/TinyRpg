using System.Text.Json;

public class Storage
{
    private Dictionary<string, object> _saveContent = new();
    private string _saveDataPath;

    public Storage(string saveDataPath = "save_data.json", int saveSlots = 3)
    {
        _saveDataPath = saveDataPath;
    }

    public bool Load()
    {
        try
        {
            if (!File.Exists(_saveDataPath))
                return false;
            
            string json = File.ReadAllText(_saveDataPath);
            
            Dictionary<string, object>? saveContent = JsonSerializer
                .Deserialize<Dictionary<string, object>>(json);

            if (saveContent is null)
                return false;

            _saveContent = saveContent;

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Save()
    {
        try
        {
            string json = JsonSerializer.Serialize(
                _saveContent,
                JsonConfig.GetJsonSerializerOptions()
            );
            
            File.WriteAllText(_saveDataPath, json);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Store(string path, Resource resource)
    {
        var sections = GetPathSections(path.ToLower());
        var currentSection = _saveContent;

        foreach (var section in sections[..^1])
        {
            currentSection = ForceGetSection(currentSection, section);
        }

        currentSection[sections[^1]] = resource;

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public T? GetStored<T>(string path) where T : Resource
    {
        object? foundPath = FindPath(path);

        if (foundPath is JsonElement jsonElement)
        {
            foundPath = JsonSerializer.Deserialize<T>(jsonElement);
        }

        if (foundPath is not T validObj) return default;

        return validObj;
    }

    private List<string> GetPathSections(string path)
    {
        return path.Split('.', '/').ToList();
    }

    private object? FindPath(string path)
    {
        List<string> sections = GetPathSections(path.ToLower());
        if (sections.Count == 0) return default;

        Dictionary<string, object> currentSection = _saveContent;
        
        foreach (var section in sections[..^1])
        {
            if (!currentSection.TryGetValue(section, out object? foundSection)) return default;

            if (foundSection is JsonElement jsonElement)
            {
                currentSection = jsonElement.Deserialize<Dictionary<string, object>>()!;
                continue;
            }

            if (foundSection is Dictionary<string, object> validSection)
            {
                currentSection = validSection;
                continue;
            }

            return default;
        }

        return currentSection.GetValueOrDefault(sections[^1]);
    }

    private static Dictionary<string, object> ForceGetSection(Dictionary<string, object> parent, string name)
    {
        if (!parent.TryGetValue(name, out var value) ||
            value is not Dictionary<string, object> section
        )
        {
            section = new();
            parent[name] = section;
        }

        return section;
    }
}
