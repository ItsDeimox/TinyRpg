internal class InventoryCommandInput() : CommandInputComponent("inv", "Show your inventory")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);

        Inventory? inventory = GetComponent<Inventory>();

        if (inventory == null)
        {
            Console.WriteLine("You have no inventory.");
            return;
        }

        TerminalDecorator.ShowHeader("Inventory");

        foreach (var item in inventory.GetItems())
        {
            Console.WriteLine($" {item.Name} x{item.GetStack()}");
        }

        TerminalDecorator.ShowFooter(19);
    }
}
