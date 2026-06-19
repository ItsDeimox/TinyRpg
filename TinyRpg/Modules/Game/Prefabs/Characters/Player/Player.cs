internal class Player : Node
{
    public Player() : base("Player")
    {
        //AddComponent(new NameChanger());
        //AddComponent(new NameChangerCommandInputComponent());

        AddComponent(new HealthComponent());
        AddComponent(new StarterInventory());
        //AddComponent(new CharacterAutoUpgrader());
        AddComponent(new BossAutoUpgrader());

        AddComponent(new BossfyCommandInput());
        AddComponent(new AddDamageAmuletCommand());
        AddComponent(new AddXpInputCommand());
        AddComponent(new StatsCommandInputComponent());
        AddComponent(new InventoryCommandInput());

        AddNode(new StatsObject());
    }
}
