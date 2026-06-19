internal class MainScene : Scene
{
    public MainScene()
    {
        AddNode(new RpgNode());
        AddNode(new InitCharacter());
    }
}
