internal class BossfyComponent : Component
{
    public override void OnStart()
    {
        base.OnStart();

        string? oldName = GameObject?.Name ?? "Unnamed";

        GameObject?.Name = GameObject.Name + " BOSS";

        LevelComponent? levelComponent = GetComponentInChildren<LevelComponent>();
        levelComponent?.AddXp(30000);

        Console.WriteLine($"\nThe character {oldName} has become a BOSS");
    }
}
