class Terminal
{
    public static event Action<string>? OnPrint;

    public static void Print(object obj)
    {
        Console.WriteLine(obj);

        string? txt = obj.ToString();
        if (txt is null)
            return;

        OnPrint?.Invoke(txt);
    }
}
