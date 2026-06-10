[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal class SerializeFieldAttribute : Attribute
{
    public string Id { get; }

    public SerializeFieldAttribute(string id)
    {
        Id = id;
    }
}
