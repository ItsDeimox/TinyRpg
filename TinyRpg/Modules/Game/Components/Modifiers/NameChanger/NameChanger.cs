internal class NameChanger : Component, INameChanger
{
    public event INameChanger.NameChangedHandler? NameChanged;

    public void ChangeName(string newName)
    {
        string oldName = GameObject?.Name ?? "Unnamed";

        GameObject?.Name = newName;

        NameChanged?.Invoke(newName, oldName);
    }
}
