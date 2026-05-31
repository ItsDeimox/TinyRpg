internal class StatsCommandInputComponent() : CommandInputComponent("stats", "Show your character stats")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        if (GameObject != null) StatsTerminal.ShowCharacterStats(GameObject);
    }
}
