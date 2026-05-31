internal class CharacterAutoUpgrader : Component, IUpgrader
{
    public event Action? OnUpgrade;

    public override void OnStart()
    {
        base.OnStart();

        LevelComponent? levelComponent = GetComponent<LevelComponent>();
        levelComponent?.OnLevelUp += OnLevelUp;
    }

    public void Upgrade()
    {
        OnUpgrade?.Invoke();

        DamageComponent? damageComponent = GetComponent<DamageComponent>();
        ArmorComponent? armorComponent = GetComponent<ArmorComponent>();
        HealthComponent? healthComponent = GetComponent<HealthComponent>();

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
