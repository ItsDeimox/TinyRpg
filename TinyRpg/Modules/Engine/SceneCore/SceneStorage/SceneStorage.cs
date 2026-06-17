internal class SceneStorage
{
    public event Action<Scene>? OnSceneSave;
    public event Action<Scene>? OnSceneLoad;

    private readonly GameStorage _gameStorage = new();

    public void SaveSceneComponents(Scene scene)
    {
        List<ISaveble> savebles = GetSceneSavebleComponents(scene);

        savebles.ForEach(s => s.OnSave(_gameStorage));

        _gameStorage.Save();

        OnSceneSave?.Invoke(scene);
    }

    public void LoadSceneComponents(Scene scene)
    {
        List<ISaveble> savebles = GetSceneSavebleComponents(scene);

        _gameStorage.Load();

        savebles.ForEach(s => s.OnLoad(_gameStorage));

        OnSceneLoad?.Invoke(scene);
    }

    private List<ISaveble> GetSceneSavebleComponents(Scene scene)
    {
        return scene
            .GetComponentList()
            .OfType<ISaveble>()
            .ToList();
    }
}
