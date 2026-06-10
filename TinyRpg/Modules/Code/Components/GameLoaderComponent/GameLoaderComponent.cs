internal class GameLoaderComponent : Component
{
    public override void OnStart()
    {
        base.OnStart();

        SceneStorage sceneStorage = new();

        Console.WriteLine("\nLoading game...");

        bool loaded = sceneStorage.Load();

        if (!loaded)
        {
            Console.WriteLine("An error occurred while trying to load the game");
            return;
        }

        Console.WriteLine("\nGame succesfully loaded!\n");

        Thread.Sleep(2);
    }
}
