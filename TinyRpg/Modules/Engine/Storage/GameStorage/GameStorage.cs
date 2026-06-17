using System.Text.Json;

internal class GameStorage
{
    private GameStorageResource _gameStorageResource = new();
    private int _currentSaveSlotIndex = 0;
    private string _gameDataPath;

    public GameStorage(string gameDataPath = "game_data.json", int saveSlots = 3)
    {
        _gameDataPath = gameDataPath;
        AddEmptySlots(saveSlots);
        SelectSlot(0);
    }

    public bool Load()
    {
        try
        {
            if (!File.Exists(_gameDataPath)) return false;
            
            string json = File.ReadAllText(_gameDataPath);
            
            GameStorageResource? gameStorageResource = JsonSerializer
                .Deserialize<GameStorageResource>(json);

            if (
                gameStorageResource is null || 
                gameStorageResource
                .SaveSlotResources
                .Count == 0
            ) return false;

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
            string json = JsonSerializer.Serialize(
                _gameStorageResource,
                JsonConfig.GetJsonSerializerOptions()
            );
            
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
        SaveSlotResource? currentSaveSlot = GetCurrentSaveSlot();
        if (currentSaveSlot is null) return;

        var sections = GetPathSections(path.ToLower());
        var currentSection = currentSaveSlot.Content;

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

    public void SelectSlot(int slot)
    {
        _currentSaveSlotIndex = slot;
    }

    public List<SaveSlotResource> GetSaveSlots()
    {
        return _gameStorageResource.SaveSlotResources;
    }

    public void UdapteCurrentSlotInfo(Resource saveSlotInfo)
    {
        GetCurrentSaveSlot()?.Info = saveSlotInfo;
    }

    private void AddEmptySlots(int amount)
    {
        amount = amount > 0 ? amount : 1;

        for (int i = 0; i < amount; i++)
        {
            _gameStorageResource.SaveSlotResources.Add(new());
        }
    }

    private SaveSlotResource? GetCurrentSaveSlot()
    {
        return _gameStorageResource
            .SaveSlotResources
            .ElementAtOrDefault(_currentSaveSlotIndex);
    }

    private List<string> GetPathSections(string path)
    {
        return ($"slot_{_currentSaveSlotIndex}.{path}").Split('.', '/').ToList();
    }

    private object? FindPath(string path)
    {
        SaveSlotResource? saveSlotResource = GetCurrentSaveSlot();
        if (saveSlotResource is null) return default;

        List<string> sections = GetPathSections(path.ToLower());
        if (sections.Count == 0) return default;

        Dictionary<string, object> currentSection = saveSlotResource.Content;
        
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
