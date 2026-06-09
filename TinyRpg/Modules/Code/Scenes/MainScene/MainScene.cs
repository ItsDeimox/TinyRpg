internal class MainScene : Scene
{
    public MainScene()
    {
        AddGameObject(new RpgGameObject());

        GameObject player = new InitCharacter();

        AddGameObject(player);

        object? serializedPlayer = GameObjectSerializer.Serialize(player);

        Console.WriteLine($"Serialized Player: {serializedPlayer}");
    }
}
