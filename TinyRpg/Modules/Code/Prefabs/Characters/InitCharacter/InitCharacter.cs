internal class InitCharacter : GameObject
{
    public InitCharacter() : base("Player")
    {
        AddComponent(new NameChanger());
        AddComponent(new NameChangerCommandInputComponent());

        AddComponent(new StarterInventory());
        AddComponent(new AddDamageAmuletCommand());
        AddComponent(new CharacterAutoUpgrader());
        //AddComponent(new BossAutoUpgrader());
        //AddComponent(new BosfyComponent());
        AddComponent(new BossfyCommandInput());

        AddComponent(new AddXpInputCommand());
        AddComponent(new StatsCommandInputComponent());
        AddComponent(new InventoryCommandInput());

        AddGameObject(new StatsObject());
    }
}
