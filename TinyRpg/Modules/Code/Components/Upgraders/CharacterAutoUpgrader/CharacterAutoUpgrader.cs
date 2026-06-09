internal class CharacterAutoUpgrader : Component, IUpgrader
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
        OnUpgrade?.Invoke();

        DamageComponent? damageComponent = GetComponentInChildren<DamageComponent>();
        ArmorComponent? armorComponent = GetComponentInChildren<ArmorComponent>();
        HealthComponent? healthComponent = GetComponentInChildren<HealthComponent>();

        damageComponent?.AddValue(1);
        armorComponent?.AddValue(1);
        healthComponent?.AddMaxHealth(2);
    }

    private void OnLevelUp(int level)
    {
        Upgrade();
        Console.WriteLine($"Congratulations! You've reached level {level}!");
    }
}
