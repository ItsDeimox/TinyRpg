internal static class TerminalDecorator
{
    public static void ShowHeader(string title)
    {
        Console.WriteLine($"\n/===[ {title} ]===\\\n");
    }

    public static void ShowFooter(int size = 5)
    {
        Console.WriteLine($"\n\\{new string('=', size)}/\n");
    }
}
