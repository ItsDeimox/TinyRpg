internal class MainScene : Scene
{
    public MainScene()
    {
        AddGameObject(new RpgGameObject());
        AddGameObject(new InitCharacter());
    }
}
