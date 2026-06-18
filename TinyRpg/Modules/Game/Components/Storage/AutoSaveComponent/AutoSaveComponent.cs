internal class AutoSaveComponent<T> : Component, ISaveble where T : Resource
{
    private readonly string _path;
    private readonly IResourceProvider<T> _resourceProvider;

    public AutoSaveComponent(string path, IResourceProvider<T> resourceProvider)
    {
        _path = path;
        _resourceProvider = resourceProvider;
    }

    public void OnLoad(GameStorage gameStorage)
    {
        T? resource = gameStorage.GetStored<T>(_path);
        if (resource is null) return;

        _resourceProvider.Resource = resource;
    }

    public void OnSave(GameStorage gameStorage)
    {
        gameStorage.Store(_path, _resourceProvider.Resource);
    }
}
