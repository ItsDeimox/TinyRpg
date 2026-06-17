internal class RpgGameObject : GameObject
{
    public RpgGameObject() : base("RpgGame")
    {
        AddComponent(new GameLoaderComponent());
        AddComponent(new RpgGameGreatingsComponent());
        AddComponent(new HelpCommandInputComponent());
        AddComponent(new ClearCommandInputComponent());
        AddComponent(new ExitCommandInputComponent());
        AddComponent(new ChangeSceneCommandInputComponent());
        AddComponent(new GameSaveSystemComponent());
        AddComponent(new SaveGameCommandInput());
    }
}
