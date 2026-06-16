internal class ClearCommandInputComponent() : CommandInputComponent("clear", "Clear the console")
{
    public override void OnCommand(string[]? args)
    {
        base.OnCommand(args);
        Console.Clear();
    }
}
