internal class LevelComponent : Component, ILevelComponent
{
    public event Action<int>? OnLevelUp;
    public event Action<int>? OnXpAdded;

    [SerializeField("level")]
    private int _level = 1;

    [SerializeField("xp")]
    private int _xp = 0;

    private int _maxXp { get; set; }

    public LevelComponent()
    {
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
        if (_xp < _maxXp) return;

        LevelUp();
        TryLevelUp();
    }

    private void LevelUp()
    {
        _level += 1;
        _xp -= _maxXp;

        UpdateMaxXp();

        OnLevelUp?.Invoke(_level);
    }
}
