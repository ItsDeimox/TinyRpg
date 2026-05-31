internal class ChangeSceneCommandInputComponent() : CommandInputComponent("scenes", "Change the current scene for a custom one")
{
    private Dictionary<string, Scene> _avaliableScenes = new();

    public override void OnStart()
    {
        base.OnStart();

        _avaliableScenes["main"] = ScenesLib.MainScene;
        _avaliableScenes["op"] = ScenesLib.CenaDeMerda;
    }

    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        ShowAvaliableScenes();

        Console.Write(">> ");
        string? choice = Console.ReadLine();

        if (choice == null)
        {
            Console.WriteLine("\nInvalid input");
            return;
        }

        Scene? scene = GetScene(choice);
        
        if (scene == null)
        {
            Console.WriteLine($"\nCan't find \"{choice}\" scene");
            return;
        }

        Engine.ChangeScene(scene);
    }

    private void ShowAvaliableScenes()
    {
        RpgTerminalPresets.ShowHeader("CHOOSE A SCENE");

        foreach (var sceneName in _avaliableScenes.Keys)
        {
            Console.WriteLine($"[ {sceneName} ]");
        }

        RpgTerminalPresets.ShowFooter(24);
    }

    private Scene? GetScene(string sceneName)
    {
        return _avaliableScenes.GetValueOrDefault(sceneName);
    }
}
