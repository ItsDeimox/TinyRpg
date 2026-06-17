internal class LevelComponent : Component, ILevelComponent, ISaveble
{
    public event Action<int>? OnLevelUp;
    public event Action<int>? OnXpAdded;

    private LevelResource _levelResource = new();
    private int _maxXp { get; set; }

    public LevelComponent()
    {
        UpdateMaxXp();
    }

    public void AddXp(int xp)
    {
        _levelResource.Xp += xp;

        OnXpAdded?.Invoke(xp);

        TryLevelUp();
    }

    public int GetLevel()
    {
        return _levelResource.Level;
    }

    public int GetMaxXp()
    {
        return _maxXp;
    }

    public int GetXp()
    {
        return _levelResource.Xp;
    }

    private void UpdateMaxXp()
    {
        _maxXp = (int) Math.Pow(3, _levelResource.Level);
    }

    private void TryLevelUp()
    {
        if (!CanLevelUp()) return;
        LevelUp();
        TryLevelUp();
    }

    private bool CanLevelUp()
    {
        return _levelResource.Xp >= _maxXp;
    }

    private void LevelUp()
    {
        _levelResource.Level += 1;
        _levelResource.Xp -= _maxXp;

        UpdateMaxXp();

        OnLevelUp?.Invoke(_levelResource.Level);
    }

    public void OnSave(GameStorage gameStorage)
    {
        gameStorage.Store("player.level", _levelResource);
    }

    public void OnLoad(GameStorage gameStorage)
    {
        LevelResource? levelResource = gameStorage.GetStored<LevelResource>("player.level");
        if (levelResource is null) return;

        _levelResource = levelResource;

        UpdateMaxXp();
    }
}
