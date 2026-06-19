internal class DamageComponent : BasicStatComponent
{
    [ResourceField]
    private DamageResource _damageResource { get; set; } = new();

    public DamageComponent(int initialValue = 0) : base("Damage Stats", initialValue)
    {
        _damageResource.Damage = initialValue;
    }

    public override void OnStart()
    {
        base.OnStart();

        OnValueChanged += OnDamageChanged;
        SetValue(_damageResource.Damage);
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageResource.Damage = newDamage;
    }
}