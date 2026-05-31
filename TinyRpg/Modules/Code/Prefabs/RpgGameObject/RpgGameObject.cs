internal class RpgGameObject : GameObject
{
    public RpgGameObject(string name = "RpgGame") : base(name)
    {
        AddComponent(new RpgGameGreatingsComponent());
        AddComponent(new HelpCommandInputComponent());
        AddComponent(new ClearCommandInputComponent());
    }
}
