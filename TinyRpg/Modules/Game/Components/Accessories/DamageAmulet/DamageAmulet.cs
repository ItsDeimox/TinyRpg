internal class DamageAmulet : Component
{
    public void Equip()
    {
        base.OnStart();

        DamageComponent? damageComponent = GetComponentInChildren<DamageComponent>();
        damageComponent?.AddValue(10);
    }
}
