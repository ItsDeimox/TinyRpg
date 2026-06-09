internal class StatsObject : GameObject
{
    public StatsObject() : base("Stats")
    {
        AddComponent(new HealthComponent());
        AddComponent(new DamageComponent());
        AddComponent(new ArmorComponent());

        LevelComponent? levelComponent = new();

        AddComponent(levelComponent);

        levelComponent.AddXp(99999);

        string serializedObject = Serializer.Serialize(levelComponent);
        Console.WriteLine($"\nSerialized Level: {serializedObject}");

        LevelComponent? deserializedLevelComponent = Serializer.Deserialize<LevelComponent>(serializedObject);
        Console.WriteLine($"\nDeserialized Level: Type: {deserializedLevelComponent}");
        Console.WriteLine($"Level: {deserializedLevelComponent?.GetLevel()}");
        Console.WriteLine($"XP: {deserializedLevelComponent?.GetXp()}");
    }
}
