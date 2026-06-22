internal class NameChangerCommandInputComponent : CommandInputComponent
{
    private bool _changeOnInit;

    public NameChangerCommandInputComponent(bool changeOnInit = true) : base(
        "change_name",
        "Change the name of your character. Usage: change_name [new_name]"
    )
    {
        _changeOnInit = changeOnInit;
    }

    public override void OnStart()
    {
        base.OnStart();

        if (!_changeOnInit) return;

        PromptAnimations.GradualText("\nHELLO, TRAVELER! WELCOME TO THE WORLD OF TINY RPG!");
        PromptAnimations.GradualText("\nChose your name [ Default = Player ]: ");

        string? choice = Console.ReadLine();
        string newName = choice == null || choice.Trim() == "" ? "Player" : choice.Trim();

        OnCommand(new[] { newName });
    }

    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        NameChanger? nameChanger = GetComponent<NameChanger>();

        if (nameChanger == null)
        {
            Console.WriteLine("\nNameChanger component not found. Cannot change name.");
            return;
        }

        string? newName = args?.ElementAtOrDefault(0);

        if (newName == null)
        {
            Console.WriteLine("\nPlease provide a new name. Usage: change_name [new_name]");
            return;
        }

        nameChanger.ChangeName(newName);

        Console.WriteLine($"\nName changed successfully to: \"{newName}\"");
    }
}
