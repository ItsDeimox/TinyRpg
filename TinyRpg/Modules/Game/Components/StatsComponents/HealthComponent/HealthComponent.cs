internal class HealthComponent : Component, IHealthComponent
{
    public event Action<int, int>? OnHealthChanged;
    public event Action<int>? OnAddHealth;
    public event Action<int>? OnSubHealth;

    private int _maxHealth;

    private int _health;

    public HealthComponent() : this(100) { }

    public HealthComponent(int maxHealth = 100)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public float GetHealthPercentage()
    {
        return (float)_health / (float)_maxHealth;
    }

    public void Add(int amount)
    {
        int oldHealth = _health;

        _health += amount;
        _health = Math.Min(_health, _maxHealth);

        if (oldHealth != _health)
        {
            OnAddHealth?.Invoke(amount);
            OnHealthChanged?.Invoke(oldHealth, _health);
        }
    }

    public void Sub(int amount)
    {
        int oldHealth = _health;

        _health -= amount;
        _health = Math.Max(_health, 0);

        if (oldHealth != _health)
        {
            OnSubHealth?.Invoke(amount);
            OnHealthChanged?.Invoke(oldHealth, _health);
        }
    }

    public void AddMaxHealth(int amount)
    {
        _maxHealth += amount;
    }
}
