internal abstract class CommandInputComponent : Component, ICommandInputComponent
{
    public string Name { get; private set; }
    public string Description {  get; private set; }

    public CommandInputComponent(string name, string description)
    {
        Name = name;
        Description = description;

        CommandManager.AddCommand(this);
    }

    public override void OnCommandInput(CommandInput commandInput)
    {
        if (commandInput.Name.ToLower() != Name.ToLower()) return;

        OnCommand(commandInput.Args);
    }

    public virtual void OnCommand(string[]? args = null) { }
}
