internal class RpgGameGreatingsComponent : Component
{
    public override void OnStart()
    {
        //Console.Clear();
        Console.WriteLine("╔─╦─╦─╦─╗                  ╔─╦─╦─╦─╗");
        Console.WriteLine("╠╦╬═╩═╩═╩══════════════════╩═╩═╩═╬╦╣");
        Console.WriteLine("║║║ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ║║║");
        Console.WriteLine("║║║ ░░! WELLCOME TO TINY RPG !░░ ║║║");
        Console.WriteLine("║║║ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ║║║");
        Console.WriteLine("╠╩╬══════════╗ ░░░░░░ ╔══════════╬╩╣");
        Console.WriteLine("║ ║ ╔╗ ╔╗ ╔╗ ╚════════╝ ╔╗ ╔╗ ╔╗ ║ ║");
        Console.WriteLine("\nYou can write \"help\" to show the avaliable commands");
    }
}
