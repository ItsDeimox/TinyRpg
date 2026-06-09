internal class SerializableField : ISerializableField
{
    public string Id { get; set; }
    public object Value { get; set; }
    public string Type { get; set; }

    public SerializableField(string id, object value, string type)
    {
        Id = id;
        Value = value;
        Type = type;
    }
}
