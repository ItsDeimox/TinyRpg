internal interface ISerializableObject
{
    string TypeName { get; set; }
    List<SerializableField> Fields { get; set; }
}
