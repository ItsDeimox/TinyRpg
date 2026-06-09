internal class LevelComponent : Component, ILevelComponent
{
    public event Action<int>? OnLevelUp;
    public event Action<int>? OnXpAdded;

    private int _level;
    private int _xp;
    private int _maxXp;

    public LevelComponent(int level = 1)
    {
        _level = level;
        UpdateMaxXp();
    }

    public void AddXp(int xp)
    {
        _xp += xp;

        OnXpAdded?.Invoke(xp);

        TryLevelUp();
    }

    public int GetLevel()
    {
        return _level;
    }

    public int GetMaxXp()
    {
        return _maxXp;
    }

    public int GetXp()
    {
        return _xp;
    }

    private void UpdateMaxXp()
    {
        _maxXp = (int) Math.Pow(3, _level);
    }

    private void TryLevelUp()
    {
        if (!CanLevelUp()) return;
        LevelUp();
        TryLevelUp();
    }

    private bool CanLevelUp()
    {
        return _xp >= _maxXp;
    }

    private void LevelUp()
    {
        _level += 1;
        _xp -= _maxXp;

        UpdateMaxXp();

        OnLevelUp?.Invoke(_level);
    }
}
