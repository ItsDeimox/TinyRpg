internal static class Engine
{
    public static event Action<Scene>? OnSceneChanged;

    public static Scene? CurrentScene { get; private set; }

    public static void ChangeScene(Scene newScene)
    {
        CurrentScene = newScene;
        OnSceneChanged?.Invoke(newScene);
        CurrentScene.OnStart();
    }

    public static void RunCommand(string command)
    {
        CommandInput commandInput = CommandHandler.GetCommandInput(command);
        CurrentScene?.OnCommandInput(commandInput);
    }
}
