internal class SerializableGameObject
{
    public string Name { get; set; }
    public List<string> Components { get; set; }

    public SerializableGameObject(string name, List<string> components)
    {
        Name = name;
        Components = components;
    }
}
