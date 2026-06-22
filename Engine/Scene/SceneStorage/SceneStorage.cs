internal class SceneStorage
{
    public event Action<Scene>? OnSceneSave;
    public event Action<Scene>? OnSceneLoad;

    private readonly Storage _engineStorage = new();

    public void SaveSceneComponents(Scene scene)
    {
        List<ISaveble> savebles = GetSceneSavebleComponents(scene);

        savebles.ForEach(s => s.OnSave(_engineStorage));

        _engineStorage.Save();

        OnSceneSave?.Invoke(scene);
    }

    public void LoadSceneComponents(Scene scene)
    {
        List<ISaveble> savebles = GetSceneSavebleComponents(scene);

        _engineStorage.Load();

        savebles.ForEach(s => s.OnLoad(_engineStorage));

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
