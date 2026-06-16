internal class StatsTerminal
{
    public static void ShowStatsHeader()
    {
        Console.WriteLine("\n/===|| Player Stats ||===\\");
    }

    public static void ShowStatsFooter()
    {
        Console.WriteLine("\n\\========================/\n");
    }

    public static void ShowLevelStat(LevelComponent levelStat)
    {
        Console.WriteLine($"\n [ Level ] {levelStat.GetLevel()}");
        Console.WriteLine($" [ XP ] {levelStat.GetXp()}/{levelStat.GetMaxXp()}");
    }

    public static void ShowHealthStat(HealthComponent healthStat)
    {
        Console.WriteLine($"\n [ Health ] {healthStat.GetHealth()}/{healthStat.GetMaxHealth()}");
    }

    public static void ShowCombatStats(GameObject character)
    {
        DamageComponent? damageComponent = character.GetComponentInChildren<DamageComponent>();
        ArmorComponent? armorComponent = character.GetComponentInChildren<ArmorComponent>();

        if (damageComponent != null) Console.WriteLine($"\n [ Damage ] {damageComponent.GetValue()}");
        if (armorComponent != null) Console.WriteLine($" [ Armor ] {armorComponent.GetValue()}");
    }

    public static void ShowCharacterStats(GameObject character)
    {
        HealthComponent? healthComponent = character.GetComponentInChildren<HealthComponent>();
        LevelComponent? levelComponent = character.GetComponentInChildren<LevelComponent>();
        
        TerminalDecorator.ShowHeader("PlayerStats");
        Console.WriteLine($" [ Name ] {character.Name}");
        if (healthComponent != null) ShowHealthStat(healthComponent);
        if (levelComponent != null) ShowLevelStat(levelComponent);
        ShowCombatStats(character);
        TerminalDecorator.ShowFooter(21);
    }
}
