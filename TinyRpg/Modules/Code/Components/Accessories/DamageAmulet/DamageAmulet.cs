internal class DamageAmulet : Component
{
    public void Equip()
    {
        base.OnStart();

        DamageComponent? damageComponent = GetComponentInChildren<DamageComponent>();
        Console.WriteLine($"Damage Component {damageComponent}");
        damageComponent?.AddValue(10);
    }
}
