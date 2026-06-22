internal class NameChanger : Component, INameChanger
{
    public event INameChanger.NameChangedHandler? NameChanged;

    public void ChangeName(string newName)
    {
        string oldName = Node?.Name ?? "Unnamed";

        Node?.Name = newName;

        NameChanged?.Invoke(newName, oldName);
    }
}
