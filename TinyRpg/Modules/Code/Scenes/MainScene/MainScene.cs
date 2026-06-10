internal class MainScene : Scene
{
    public MainScene()
    {
        AddGameObject(new RpgGameObject());

        InitCharacter player = new();

        AddGameObject(player);

        object? serializedPlayer = GameObjectSerializer.Serialize(player);

        Console.WriteLine($"Serialized Player: {serializedPlayer}");
    }
}
