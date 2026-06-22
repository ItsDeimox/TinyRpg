public class CommandInput : ICommandInput
{
    public string Name { get; private set; }
    public string[]? Args { get; private set; }

    public CommandInput(string name, string[]? args = null)
    {
        Name = name;
        Args = args;
    }
}
