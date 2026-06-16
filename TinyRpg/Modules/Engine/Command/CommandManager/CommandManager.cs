internal static class CommandManager
{
    private static List<CommandInputComponent> _avaliableCommands = new();

    public static void AddCommand(CommandInputComponent commandInput)
    {
        if (HaveCommand(commandInput.Name)) return;

        _avaliableCommands.Add(commandInput);
    }

    public static void RemoveCommand(string commandName)
    {
        CommandInputComponent? commandInput = GetCommand(commandName);

        if (commandInput == null) return;

        _avaliableCommands.Remove(commandInput);
    }

    public static bool HaveCommand(string commandName)
    {
        foreach (CommandInputComponent commandInput in _avaliableCommands)
        {
            if (commandInput.Name.ToLower().Equals(commandName.ToLower())) return true;
        }

        return false;
    }

    public static CommandInputComponent? GetCommand(string commandName)
    {
        foreach (var commandInput in _avaliableCommands)
        {
            if (commandInput.Name.ToLower().Equals(commandName.ToLower())) return commandInput;
        }

        return default;
    }

    public static string GetCommandName(string command)
    {
        return command.Split(' ')[0];
    }

    public static List<CommandInputComponent> GetAvaliableCommands()
    {
        return _avaliableCommands;
    }
}
