internal class GameLoaderComponent : Component
{
    public override void OnStart()
    {
        base.OnStart();

        var gameSaveSystemComponent = GetComponent<SaveSystemComponent>();

        if (gameSaveSystemComponent is null)
        {
            Console.WriteLine("Can't find GameSaveSystemComponent!");
            return;
        }

        Console.WriteLine("\nLoading...");

        bool loaded = gameSaveSystemComponent.Load();

        if (loaded)
        {
            Console.WriteLine("\nGame loaded successfully!\n");
        }
        else
        {
            Console.WriteLine("\nThere was a problem while loading the game");
        }
        
        Console.Clear();
    }
}
