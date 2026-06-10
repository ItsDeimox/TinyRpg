internal class SaveGameCommand() : CommandInputComponent("save_game", "Save the game")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        Console.WriteLine("\nSaving game...");

        SceneStorage sceneStorage = new();

        bool saved = sceneStorage.Save();

        if (!saved)
        {
            Console.WriteLine("\nAn error occurred while trying to save the game");
            return;
        }

        Console.WriteLine("\nGame succesfully saved!");
    }
}
