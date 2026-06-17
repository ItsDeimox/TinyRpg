internal class DamageComponent : BasicStatComponent, ISaveble
{
    private DamageResource _damageResource = new();

    public DamageComponent(int initialValue = 0) : base("Damage Stats", initialValue)
    {
        _damageResource.Damage = initialValue;
        OnValueChanged += OnDamageChanged;
    }

    public void OnLoad(GameStorage gameStorage)
    {
        var damageResource = gameStorage.GetStored<DamageResource>("player.damage");
        if (damageResource == null) return;

        _damageResource = damageResource;

        SetValue(_damageResource.Damage);
    }

    public void OnSave(GameStorage gameStorage)
    {
        gameStorage.Store("player.damage", _damageResource);
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageResource.Damage = newDamage;
    }
}