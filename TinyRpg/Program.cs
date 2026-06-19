internal class Program
{
    private static void Main()
    {
        Game game = new(ScenesLib.MainScene);
        game.Run();
    }
}
