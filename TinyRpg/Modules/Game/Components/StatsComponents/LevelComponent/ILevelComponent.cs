internal interface ILevelComponent
{
    event Action<int>? OnLevelUp;
    event Action<int>? OnXpAdded;

    int GetLevel();

    int GetXp();

    int GetMaxXp();

    void AddXp(int xp);
}
