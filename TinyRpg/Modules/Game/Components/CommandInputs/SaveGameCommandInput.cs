internal class SaveGameCommandInput() : CommandInputComponent("save", "Save the game")
{
    private GameSaveSystemComponent _gameSaveSystemComponent = new();

    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        Console.WriteLine("\nSaving...");

        bool saved = _gameSaveSystemComponent.Save();

        if (saved)
        {
            Console.WriteLine("\nGame saved successfully!");
            return;
        }

        Console.WriteLine("\n There was a problem while trying to save the game!");
    }
}
