internal interface ISerializableObject
{
    string TypeName { get; set; }
    Dictionary<string, SerializableField> Fields { get; set; }
}
