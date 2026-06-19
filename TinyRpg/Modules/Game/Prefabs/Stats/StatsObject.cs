internal class StatsObject : Node
{
    public StatsObject() : base("Stats")
    {
        AddComponent(new DamageComponent());
        AddComponent(new ArmorComponent());
        AddComponent(new LevelComponent());
        AddComponent(new HealthComponent());

        AddComponent(new AutoSaveComponent<LevelComponent, LevelResource>("player.level"));
        AddComponent(new AutoSaveComponent<HealthComponent, HealthResource>("player.health"));
    }
}
