internal class LevelComponent : Component, ILevelComponent
{
    public event Action<int>? OnLevelUp;
    public event Action<int>? OnXpAdded;

    private int _maxXp { get; set; }

    [ResourceField]
    private LevelResource LevelResource { get; set; } = new();

    public LevelComponent()
    {
        UpdateMaxXp();
    }

    public void AddXp(int xp)
    {
        LevelResource.Xp += xp;

        OnXpAdded?.Invoke(xp);

        TryLevelUp();
    }

    public int GetLevel()
    {
        return LevelResource.Level;
    }

    public int GetMaxXp()
    {
        return _maxXp;
    }

    public int GetXp()
    {
        return LevelResource.Xp;
    }

    private void UpdateMaxXp()
    {
        _maxXp = (int) Math.Pow(3, LevelResource.Level);
    }

    private void TryLevelUp()
    {
        if (!CanLevelUp()) return;
        LevelUp();
        TryLevelUp();
    }

    private bool CanLevelUp()
    {
        return LevelResource.Xp >= _maxXp;
    }

    private void LevelUp()
    {
        LevelResource.Level += 1;
        LevelResource.Xp -= _maxXp;

        UpdateMaxXp();

        OnLevelUp?.Invoke(LevelResource.Level);
    }

    //public void OnSave(EngineStorage engineStorage)
    //{
    //    engineStorage.Store("player.level", Resource);
    //}

    //public void OnLoad(EngineStorage engineStorage)
    //{
    //    LevelResource? levelResource = engineStorage.GetStored<LevelResource>("player.level");
    //    if (levelResource is null) return;

    //    Resource = levelResource;

    //    UpdateMaxXp();
    //} The autosave component has been created, but it is not yet in use.
}
