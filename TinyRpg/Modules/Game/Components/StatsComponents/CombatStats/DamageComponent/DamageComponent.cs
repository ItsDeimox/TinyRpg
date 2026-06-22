internal class DamageComponent : BasicStatComponent
{
    private DamageResource _damageResource = new();

    [ResourceField]
    private DamageResource DamageResource
    {
        get => _damageResource;
        set => SetValue(value.Damage);
    }

    public DamageComponent(int initialValue = 0) : base("Damage Stats", initialValue)
    {
        SetValue(initialValue);
    }

    public override void OnStart()
    {
        base.OnStart();

        OnValueChanged += OnDamageChanged;
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageResource.Damage = newDamage;
    }
}