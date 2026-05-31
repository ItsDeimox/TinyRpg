internal static class CommandHandler
{
    public static CommandInput GetCommandInput(string command)
    {
        string commandName = GetCommandName(command);
        string[] commandArgs = GetCommandArgs(command);

        return new CommandInput(commandName, commandArgs);
    }

    private static string GetCommandName(string command)
    {
        return command.Split(" ")[0];
    }

    private static string[] GetCommandArgs(string command)
    {
        return command.Split(" ").Skip(1).ToArray();
    }
}
