internal class RpgGameObject : GameObject
{
    public RpgGameObject(string name = "RpgGame") : base(name)
    {
        AddComponent(new GameLoaderComponent());
        AddComponent(new SaveGameCommand());
        AddComponent(new RpgGameGreatingsComponent());
        AddComponent(new HelpCommandInputComponent());
        AddComponent(new ClearCommandInputComponent());
        AddComponent(new ExitCommandInputComponent());
        AddComponent(new ChangeSceneCommandInputComponent());
    }
}
