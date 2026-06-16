internal class SaveSlotResource : Resource
{
    public SaveSlotInfoResource Info { get; set; } = new();
    public Dictionary<string, object> Content { get; set; } = new();
}
