internal class AddXpInputCommand() : CommandInputComponent("add_xp", "add xp to player")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        LevelComponent? levelComponent = GetComponentInChildren<LevelComponent>();

        if (levelComponent == null)
        {
            Console.WriteLine("\nLevelComponent not found on player. Cannot add XP.");
            return;
        }

        if (!int.TryParse(args?.FirstOrDefault(), out int xp))
        {
            Console.WriteLine("\nInvalid XP amount. Please provide a valid integer.");
            return;
        }

        levelComponent.AddXp(xp);

        Console.WriteLine($"\nAdded {xp} XP to player.", xp);
    }
}
