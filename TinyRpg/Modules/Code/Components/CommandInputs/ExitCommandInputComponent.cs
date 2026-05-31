internal class ExitCommandInputComponent() : CommandInputComponent("exit", "Exit from game ;-;")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        Environment.Exit(0);
    }
}
