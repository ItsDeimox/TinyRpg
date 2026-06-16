internal interface INameChanger
{
    delegate void NameChangedHandler(string newName, string oldName);
    event NameChangedHandler? NameChanged;

    void ChangeName(string newName);
}
