internal class CommandLoop
{
    public void StartLoop()
    {
        Console.Write("\n>> ");

        string? command = Console.ReadLine();

        if (command == null)
        {
            Console.WriteLine("\nYou should write something!");

            StartLoop();

            return;
        }

        if (!CommandManager.HaveCommand(command))
        {
            Console.WriteLine($"\nUnknow command \"{command}\" ");

            StartLoop();

            return;
        }

        Engine.RunCommand(command);

        StartLoop();
    }
}
