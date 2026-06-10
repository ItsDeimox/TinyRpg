internal class SceneStorage : IStorageSystem
{
    private string _fileName;

    public SceneStorage(string data_path = "game_data.json")
    {
        _fileName = data_path;
    }

    public bool Load()
    {
        string sceneJson = File.ReadAllText(_fileName);

        Scene? scene = SceneSerializer.Deserialize<Scene>(sceneJson);

        return scene != null;
    }

    public bool Save()
    {
        Scene? currentScene = SceneManager.GetCurrentScene();
        if (currentScene == null) return false;

        string? serializedScene = SceneSerializer.Serialize(currentScene);
        if (serializedScene == null) return false;

        File.WriteAllText(_fileName, serializedScene);

        Console.WriteLine($"Saved Game: {serializedScene}");

        return true;
    }
}
