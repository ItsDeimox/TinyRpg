using System.Text.Json;

internal class GameStorage : ISaveble
{
    private GameStorageResource _gameStorageResource = new();

    private string _gameDataPath;
    private SaveSlotResource _currentSaveSlot = new();

    public GameStorage(string gameDataPath = "game_data.json")
    {
        _gameDataPath = gameDataPath;
    }

    public bool Load()
    {
        try
        {
            if (!File.Exists(_gameDataPath)) return false;

            string json = File.ReadAllText(_gameDataPath);

            GameStorageResource? gameStorageResource = JsonSerializer.Deserialize<GameStorageResource>(json);
            if (gameStorageResource is null) return false;

            _gameStorageResource = gameStorageResource;

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
            string json = JsonSerializer.Serialize(_gameStorageResource);

            File.WriteAllText(_gameDataPath, json);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Store(string path, Resource resource)
    {
        var sections = GetPathSections(path);
        var currentSection = _currentSaveSlot.Content;

        foreach (var section in sections[..^1])
        {
            currentSection = ForceGetSection(currentSection, section);
        }

        currentSection[sections[^1]] = resource;
    }

    public T? GetStored<T>(string path) where T : Resource
    {
        object? foundPath = FindPath(path);
        if (foundPath is not T validObj) return default;

        return validObj;
    }

    private List<string> GetPathSections(string path)
    {
        return path.Split('.', '/').ToList();
    }

    private object? FindPath(string path)
    {
        List<string> sections = GetPathSections(path);
        if (sections.Count == 0) return default;

        Dictionary<string, object>? currentSection = _currentSaveSlot.Content;

        foreach (var section in sections)
        {
            object? foundSection = currentSection.GetValueOrDefault(section);

            if (currentSection is not Dictionary<string, object> validSection) continue;

            currentSection = validSection;
        }

        return currentSection;
    }

    private Dictionary<string, object> ForceGetSection(Dictionary<string, object> parent, string name)
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
