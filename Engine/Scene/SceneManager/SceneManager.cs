internal static class SceneManager
{
    public static event Action<Scene>? SceneChanged;
    public static event Action<Scene>? SceneAdded;
    public static event Action<Scene>? SceneRemoved;

    private static Scene? _currentScene;
    private static List<Scene> _scenes = new();

    public static void AddScene(Scene scene)
    {
        _scenes.Add(scene);
        SceneAdded?.Invoke(scene);
    }

    public static void RemoveScene(Scene scene)
    {
        _scenes.Remove(scene);
        SceneRemoved?.Invoke(scene);
    }

    public static void ChangeScene(Scene scene)
    {
        _currentScene = scene;
        SceneChanged?.Invoke(scene);
    }

    public static List<Scene> GetScenes()
    {
        return _scenes;
    }

    public static void StartCurrentScene()
    {
        _currentScene?.OnStart();
    }

    public static Scene? GetCurrentScene()
    {
        return _currentScene;
    }

    public static void RunCommandOnCurrentScene(string command)
    {
        CommandInput commandInput = CommandHandler.GetCommandInput(command);
        _currentScene?.OnCommandInput(commandInput);
    }
}
