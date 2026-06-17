internal class HealthComponent : Component, IHealthComponent, ISaveble
{
    public event Action<int, int>? OnHealthChanged;
    public event Action<int>? OnAddHealth;
    public event Action<int>? OnSubHealth;

    private HealthResource _healthResource = new();

    public HealthComponent() : this(100) { }

    public HealthComponent(int maxHealth = 100)
    {
        _healthResource.MaxHealth = maxHealth;
        _healthResource.Health = maxHealth;
    }

    public int GetHealth()
    {
        return _healthResource.Health;
    }

    public int GetMaxHealth()
    {
        return _healthResource.MaxHealth;
    }

    public float GetHealthPercentage()
    {
        return (float)_healthResource.Health / (float)_healthResource.MaxHealth;
    }

    public void Add(int amount)
    {
        int oldHealth = _healthResource.Health;

        _healthResource.Health += amount;
        _healthResource.Health = Math.Min(_healthResource.Health, _healthResource.MaxHealth);

        if (oldHealth != _healthResource.Health)
        {
            OnAddHealth?.Invoke(amount);
            OnHealthChanged?.Invoke(oldHealth, _healthResource.Health);
        }
    }

    public void Sub(int amount)
    {
        int oldHealth = _healthResource.Health;

        _healthResource.Health -= amount;
        _healthResource.Health = Math.Max(_healthResource.Health, 0);

        if (oldHealth != _healthResource.Health)
        {
            OnSubHealth?.Invoke(amount);
            OnHealthChanged?.Invoke(oldHealth, _healthResource.Health);
        }
    }

    public void AddMaxHealth(int amount)
    {
        _healthResource.MaxHealth += amount;
    }

    public void OnSave(GameStorage gameStorage)
    {
        gameStorage.Store("player.health", _healthResource);
    }

    public void OnLoad(GameStorage gameStorage)
    {
        var healthResource = gameStorage.GetStored<HealthResource>("player.health");
        if (healthResource != null) _healthResource = healthResource;
    }
}
