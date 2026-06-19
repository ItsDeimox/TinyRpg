internal class BossfyComponent : Component
{
    public override void OnStart()
    {
        base.OnStart();

        string? oldName = Node?.Name ?? "Unnamed";

        Node?.Name = Node.Name + " BOSS";

        LevelComponent? levelComponent = GetComponentInChildren<LevelComponent>();
        levelComponent?.AddXp(30000);

        Console.WriteLine($"\nThe character {oldName} has become a BOSS");
    }
}
