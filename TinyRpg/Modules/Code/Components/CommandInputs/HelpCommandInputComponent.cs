internal class HelpCommandInputComponent() : CommandInputComponent("help", "Show this help message")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        List<CommandInputComponent> commandInputComponents = CommandManager.GetAvaliableCommands();

        Console.WriteLine("\n\n/===[ AVALIABLE COMMANDS ]===\\\n");
        commandInputComponents.ForEach(ShowCommandInput);
        Console.WriteLine("\n\\============================/\n");
    }

    private void ShowCommandInput(CommandInputComponent commandInputComponent)
    {
        Console.WriteLine($"[{commandInputComponent.Name}] {commandInputComponent.Description}");
    }
}
