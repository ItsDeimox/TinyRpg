internal class LevelComponent : Component, ILevelComponent, IResourceProvider<LevelResource>, ISaveble
{
    public event Action<int>? OnLevelUp;
    public event Action<int>? OnXpAdded;

    private int _maxXp { get; set; }

    public LevelResource Resource { get; set; } = new();

    public LevelComponent()
    {
        UpdateMaxXp();
    }

    public void AddXp(int xp)
    {
        Resource.Xp += xp;

        OnXpAdded?.Invoke(xp);

        TryLevelUp();
    }

    public int GetLevel()
    {
        return Resource.Level;
    }

    public int GetMaxXp()
    {
        return _maxXp;
    }

    public int GetXp()
    {
        return Resource.Xp;
    }

    private void UpdateMaxXp()
    {
        _maxXp = (int) Math.Pow(3, Resource.Level);
    }

    private void TryLevelUp()
    {
        if (!CanLevelUp()) return;
        LevelUp();
        TryLevelUp();
    }

    private bool CanLevelUp()
    {
        return Resource.Xp >= _maxXp;
    }

    private void LevelUp()
    {
        Resource.Level += 1;
        Resource.Xp -= _maxXp;

        UpdateMaxXp();

        OnLevelUp?.Invoke(Resource.Level);
    }

    public void OnSave(GameStorage gameStorage)
    {
        gameStorage.Store("player.level", Resource);
    }

    public void OnLoad(GameStorage gameStorage)
    {
        LevelResource? levelResource = gameStorage.GetStored<LevelResource>("player.level");
        if (levelResource is null) return;

        Resource = levelResource;

        UpdateMaxXp();
    }
}
