internal class SerializableScene
{
    public string Name { get; }
    public List<SerializableGameObject> GameObjects { get; } = new();

    public SerializableScene(string name, List<SerializableGameObject> gameObjects)
    {
        Name = name;
        GameObjects = gameObjects;
    }
}
