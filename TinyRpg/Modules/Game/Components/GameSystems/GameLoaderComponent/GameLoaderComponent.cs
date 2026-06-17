internal class GameLoaderComponent : Component
{
    public override void OnStart()
    {
        base.OnStart();

        var gameSaveSystemComponent = GetComponent<GameSaveSystemComponent>();

        if (gameSaveSystemComponent is null)
        {
            Console.WriteLine("Can't find GameSaveSystemComponent!");
            return;
        }

        PromptAnimations.GradualText("\nLoading...");

        bool loaded = gameSaveSystemComponent.Load();

        if (loaded)
        {
            PromptAnimations.GradualText("\nGame loaded successfully!\n");
        }
        else
        {
            Console.WriteLine("\nThere was a problem while loading the game");
        }
        
        Thread.Sleep(1000);
        Console.Clear();
    }
}
