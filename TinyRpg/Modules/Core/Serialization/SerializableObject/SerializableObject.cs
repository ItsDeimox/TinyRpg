internal class SerializableObject : ISerializableObject
{
    public string TypeName { get; set; }
    public List<SerializableField> Fields { get; set; } = new();

    public SerializableObject(string typeName)
    {
        TypeName = typeName;
    }
}
