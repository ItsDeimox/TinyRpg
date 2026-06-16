internal class BossfyCommandInput() : CommandInputComponent("bossfy", "Bossfy the character, making it stronger and more powerful.")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        BossfyComponent? bossfyComponent = GetComponent<BossfyComponent>();

        if (bossfyComponent != null)
        {
            Console.WriteLine("The character is already bossified!");
            return;
        }

        AddComponent(new BossfyComponent());
    }
}
