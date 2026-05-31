internal class StatsObject : GameObject
{
    public StatsObject() : base("Stats")
    {
        AddComponent(new HealthComponent());
        AddComponent(new LevelComponent());
        AddComponent(new DamageComponent());
        AddComponent(new ArmorComponent());
    }
}
