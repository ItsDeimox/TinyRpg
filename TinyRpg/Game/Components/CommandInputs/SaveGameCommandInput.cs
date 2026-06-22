internal class SaveGameCommandInput() : CommandInputComponent("save", "Save the game")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        SaveSystemComponent? gameSaveSystemComponent = GetComponent<SaveSystemComponent>();

        if (gameSaveSystemComponent is null)
        {
            Console.WriteLine("Can't find GameSaveSystemComponent!");
            return;
        }

        PromptAnimations.GradualText("\nSaving...");

        bool saved = gameSaveSystemComponent.Save();

        if (!saved)
        {
            Console.WriteLine("\n There was a problem while trying to save the game!");
            return;
        }

        PromptAnimations.GradualText("\nGame saved successfully!");
    }
}
