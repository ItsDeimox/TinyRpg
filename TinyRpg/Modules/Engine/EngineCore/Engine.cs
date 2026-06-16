internal static class Engine
{
    public static void ChangeScene(Scene newScene)
    {
        SceneManager.ChangeScene(newScene);
        SceneManager.StartCurrentScene();
    }

    public static void RunCommand(string command)
    {
        SceneManager.RunCommandOnCurrentScene(command);
    }
}
