internal class OpCharacter : GameObject
{
    public OpCharacter()
    {
        AddComponent(new LevelComponent(100));
        AddComponent(new HealthComponent(99999));

        AddComponent(new StatsCommandInputComponent());
        AddComponent(new HelpCommandInputComponent());
        AddComponent(new CheatedRpgGameGreatings());
        AddComponent(new ChangeSceneCommandInputComponent());
    }
}
