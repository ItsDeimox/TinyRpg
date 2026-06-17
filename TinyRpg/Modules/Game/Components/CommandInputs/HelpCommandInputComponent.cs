internal class HelpCommandInputComponent() : CommandInputComponent("help", "Show this help message")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        List<CommandInputComponent> commandInputComponents = CommandManager.GetAvaliableCommands();

        TerminalDecorator.ShowHeader("AVALIABLE COMMANDS");
        commandInputComponents.ForEach(ShowCommandInput);
        TerminalDecorator.ShowFooter(28);
    }

    private void ShowCommandInput(CommandInputComponent commandInputComponent)
    {
        Console.WriteLine($" [ {commandInputComponent.Name} ] {commandInputComponent.Description}\n");
    }
}
