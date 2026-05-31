internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new(ScenesLib.MainScene);
        game.Run();
    }
}
