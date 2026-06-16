internal interface ICommandInputComponent
{
    string Name { get; }
    string Description { get; }

    void OnCommand(string[]? args = null);
}
