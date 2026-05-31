internal class InitCharacter : GameObject
{
    public InitCharacter() : base("Init Character")
    {
        AddComponent(new CharacterAutoUpgrader());
        AddComponent(new StarterInventory());
        AddComponent(new StatsCommandInputComponent());

        AddGameObject(new StatsObject());
    }
}
