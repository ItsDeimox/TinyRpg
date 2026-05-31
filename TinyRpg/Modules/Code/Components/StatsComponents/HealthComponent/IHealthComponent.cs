internal interface IHealthComponent
{
    event Action<int, int>? OnHealthChanged;
    event Action<int>? OnAddHealth;
    event Action<int>? OnSubHealth;

    int GetHealth();

    int GetMaxHealth();

    float GetHealthPercentage();

    void Add(int amount);

    void Sub(int amount);

    void AddMaxHealth(int amount);
}
