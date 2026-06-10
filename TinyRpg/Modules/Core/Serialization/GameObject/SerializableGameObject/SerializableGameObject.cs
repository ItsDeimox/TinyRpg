internal class SerializableGameObject
{
    public string Name { get; }
    public List<SerializableObject> Components { get; }
    public List<SerializableGameObject> GameObjects { get; }

    public SerializableGameObject(
        string name,
        List<SerializableObject> components,
        List<SerializableGameObject> gameObjects
    )
    {
        Name = name;
        Components = components;
        GameObjects = gameObjects;
    }
}
