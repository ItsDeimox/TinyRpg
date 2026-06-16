using System.Text.Json;

internal class GameStorage
{
    private GameStorageResource _gameStorageResource = new();
    private SaveSlotResource _currentSaveSlot = new();
    private int _currentSaveSlotIndex = 0;
    private string _gameDataPath;

    public GameStorage(string gameDataPath = "game_data.json", int saveSlots = 3)
    {
        _gameDataPath = gameDataPath;
        AddEmptySlots(saveSlots);
    }

    public bool Load()
    {
        try
        {
            if (!File.Exists(_gameDataPath)) return false;

            string json = File.ReadAllText(_gameDataPath);

            GameStorageResource? gameStorageResource = JsonSerializer
                .Deserialize<GameStorageResource>(json);

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
        var sections = GetPathSections(path.ToLower());
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

    public bool SelectSlot(int slot)
    {
        SaveSlotResource? saveSlotResource = _gameStorageResource
            .SaveSlotResources
            .ElementAtOrDefault(slot);

        if (saveSlotResource is null) return false;

        _currentSaveSlot = saveSlotResource;
        _currentSaveSlotIndex = slot;

        return true;
    }

    public List<SaveSlotResource> GetSaveSlots()
    {
        return _gameStorageResource.SaveSlotResources;
    }

    public void UdapteCurrentSlotInfo(Resource saveSlotInfo)
    {
        _currentSaveSlot.Info = saveSlotInfo;
    }

    private void AddEmptySlots(int amount)
    {
        amount = amount > 0 ? amount : 1;

        for (int i = 0; i < amount; i++)
        {
            _gameStorageResource.SaveSlotResources.Add(new());
        }
    }

    private List<string> GetPathSections(string path)
    {
        return ($"slot_{_currentSaveSlotIndex}.{path}" + path).Split('.', '/').ToList();
    }

    private Dictionary<string, object>? FindPath(string path)
    {
        List<string> sections = GetPathSections(path.ToLower());
        if (sections.Count == 0) return default;

        Dictionary<string, object> currentSection = _currentSaveSlot.Content;

        foreach (var section in sections)
        {
            object? foundSection = currentSection.GetValueOrDefault(section);
            if (foundSection is not Dictionary<string, object> validSection) return default;

            currentSection = validSection;
        }

        return currentSection;
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
