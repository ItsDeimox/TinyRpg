internal class HealthPotion(string name = "HealthPotion", int maxStack = 5) : Consumable(name, maxStack)
{
    public override void OnStart()
    {
        base.OnStart();

        OnConsume += OnConsumeEvent;
    }

    private void OnConsumeEvent(Node? user, int amount)
    {
        HealthComponent? healthComponent = user?.GetComponent<HealthComponent>();

        if (healthComponent == null )
        {
            Console.WriteLine("No Health Component found!");
            return;
        }

        healthComponent.Add(healthComponent.GetMaxHealth());

        Console.WriteLine($"{user?.Name} Health Restored!");
    }
}