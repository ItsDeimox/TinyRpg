internal class DamageComponent : BasicStatComponent, ISaveble
{
    private DamageResource _damageResource = new();

    public DamageComponent(int initialValue = 0) : base("Damage Stats", initialValue)
    {
        _damageResource.Damage = initialValue;
        OnValueChanged += OnDamageChanged;
    }

    public void OnLoad(EngineStorage engineStorage)
    {
        var damageResource = engineStorage.GetStored<DamageResource>("player.damage");
        if (damageResource == null) return;

        _damageResource = damageResource;

        SetValue(_damageResource.Damage);
    }

    public void OnSave(EngineStorage engineStorage)
    {
        engineStorage.Store("player.damage", _damageResource);
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageResource.Damage = newDamage;
    }
}