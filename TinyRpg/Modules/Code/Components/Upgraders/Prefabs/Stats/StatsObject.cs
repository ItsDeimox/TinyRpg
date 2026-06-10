internal class StatsObject : GameObject
{
    public StatsObject() : base("Stats")
    {
        AddComponent(new HealthComponent());
        AddComponent(new DamageComponent());
        AddComponent(new ArmorComponent());
        AddComponent(new LevelComponent());
    }
}
