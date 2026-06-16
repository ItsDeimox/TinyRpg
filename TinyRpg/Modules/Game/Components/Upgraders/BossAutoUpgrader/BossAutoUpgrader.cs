internal class BossAutoUpgrader : Component, IUpgrader
{
    public event Action? OnUpgrade;

    public override void OnStart()
    {
        base.OnStart();

        LevelComponent? levelComponent = GetComponentInChildren<LevelComponent>();
        levelComponent?.OnLevelUp += OnLevelUp;
    }

    public void Upgrade()
    {
        DamageComponent? damageComponent = GetComponentInChildren<DamageComponent>();
        damageComponent?.AddValue(300);

        IHealthComponent? healthComponent = GetComponentInChildren<HealthComponent>();
        healthComponent?.AddMaxHealth(1000);
        healthComponent?.Add(healthComponent.GetMaxHealth());

        ArmorComponent? armorComponent = GetComponentInChildren<ArmorComponent>();
        armorComponent?.AddValue(100);

        OnUpgrade?.Invoke();
    }

    private void OnLevelUp(int newLevel)
    {
        Thread.Sleep(100);
        Upgrade();
        Console.WriteLine("\nBoss has leveled up to level " + newLevel + "! It has become even more powerful!");
    }
}
