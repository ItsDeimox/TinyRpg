internal class CommandLoop
{
    public void StartLoop()
    {
        Console.Write("\n>> ");

        string? command = Console.ReadLine();

        if (!CommandHandler.ValidateCommand(command)) {
            Console.WriteLine("\n[X] Invalid command. Say \"help\" to show avaliable commands.");

            StartLoop();

            return;
        }

        if (!CommandManager.HaveCommand(CommandManager.GetCommandName(command)))
        {
            Console.WriteLine($"\nUnknow command \"{command}\" ");

            StartLoop();

            return;
        }

        Engine.RunCommand(command);

        StartLoop();
    }
}
