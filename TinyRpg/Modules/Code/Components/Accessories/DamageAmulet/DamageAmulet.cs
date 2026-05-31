internal class DamageAmulet : Component
{
    public override void OnStart()
    {
        base.OnStart();

        DamageComponent? damageComponent = GetComponentInChildren<DamageComponent>();
        Console.WriteLine($"Damage Component {damageComponent}");
        damageComponent?.AddValue(10);
    }
}
