internal class InitCharacter : GameObject
{
    public InitCharacter() : base("Init Character")
    {
        AddComponent(new CharacterAutoUpgrader());
        AddComponent(new StarterInventory());
        AddComponent(new StatsCommandInputComponent());
        AddComponent(new AddDamageAmuletCommand());

        AddGameObject(new StatsObject());
    }
}
