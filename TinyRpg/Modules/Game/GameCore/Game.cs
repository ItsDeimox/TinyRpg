internal class Game
{
    private Scene? _currentScene;

    public Game(Scene? initScene = null)
    {
        _currentScene = initScene ?? new MainScene();
    }

    public void Run()
    {
        StartScene();
        InitMainLoop();
    }

    private void StartScene()
    {
        Engine.ChangeScene(_currentScene!);
    }

    private void InitMainLoop()
    {
        CommandLoop commandLoop = new();
        commandLoop?.StartLoop();
    }
}
