internal class GameSaveSystemComponent : Component
{
    public static event Action? OnSave;
    public static event Action? OnLoad;

    private readonly SceneStorage _sceneStorage = new();

    public bool Load()
    {
        Scene? scene = SceneManager.GetCurrentScene();
        if (scene is null) return false;

        _sceneStorage.LoadSceneComponents(scene);

        OnLoad?.Invoke();

        return true;
    }

    public bool Save()
    {
        Scene? scene = SceneManager.GetCurrentScene();
        if (scene is null) return false;

        _sceneStorage.SaveSceneComponents(scene);

        OnSave?.Invoke();

        return true;
    }
}
