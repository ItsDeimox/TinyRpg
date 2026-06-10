internal class BundaCommandInputComponent() : CommandInputComponent("bunda", "mostra a sua bunda na tela")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        Console.WriteLine("\nVocê mostrou a sua bunda na tela! Parabéns!");
    }
}
