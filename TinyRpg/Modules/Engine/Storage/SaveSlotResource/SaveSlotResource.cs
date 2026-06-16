internal class SaveSlotResource : Resource
{
    public Resource? Info { get; set; }
    public Dictionary<string, object> Content { get; set; } = new();
}
