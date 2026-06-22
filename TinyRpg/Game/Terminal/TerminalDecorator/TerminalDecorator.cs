internal static class TerminalDecorator
{
    public static void ShowHeader(string title)
    {
        Console.WriteLine($"\n    ╔═{new string('═', title.Length)}═╗    ");
        Console.WriteLine($"╔╦══║ {title} ║══╦╗");
        Console.WriteLine($"╠╝  ╚═{new string('═', title.Length)}═╝  ╚╣\n");
    }

    public static void ShowFooter(int size = 5)
    {
        Console.WriteLine($"\n║ {new string('░', size - 2)} ║");
        Console.WriteLine($"╚{new string('═', size)}╝\n");
    }
}
