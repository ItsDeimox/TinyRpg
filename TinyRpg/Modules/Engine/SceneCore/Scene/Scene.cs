internal class Scene : IScene
{
    public event Action? OnSceneStart;
    public event Action<IGameObject>? OnGameObjectAdded;
    public event Action<IGameObject>? OnGameObjectRemoved;

    private List<IGameObject> _children = new();

    public void OnStart()
    {
        OnSceneStart?.Invoke();

        foreach (var gameObject in GetDescendants())
        {
            ComponentManager.StartComponents(gameObject.GetComponentList());
            gameObject.OnComponentAdded += (IComponent component) => component.OnStart();
        }
    }

    public void OnCommandInput(CommandInput commandInput)
    {
        foreach (var gameObject in _children)
        {
            ComponentManager.RunCommandInputComponents(gameObject.GetComponentList(), commandInput);
        }
    }

    public void AddGameObject(IGameObject gameObject)
    {
        _children.Add(gameObject);

        gameObject.SetScene(this);

        OnGameObjectAdded?.Invoke(gameObject);
    }

    public void AddGameObjects(List<IGameObject> gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {
            AddGameObject(gameObject);
        }
    }

    public void RemoveGameObject(IGameObject gameObject)
    {
        _children.Remove(gameObject);

        gameObject.SetScene(null);

        OnGameObjectRemoved?.Invoke(gameObject);
    }

    public bool HasGameObject(IGameObject gameObject)
    {
        return _children.Contains(gameObject);
    }

    public IGameObject? GetGameObject(string name)
    {
        return _children.FirstOrDefault(go => go.Name == name);
    }

    public List<IGameObject> GetChildren()
    {
        return _children;
    }

    public List<IGameObject> GetDescendants()
    {
        return _children
            .SelectMany(go => go.GetDescendants())
            .Concat(_children)
            .ToList();
    }

    public List<IComponent> GetComponentList()
    {
        return GetDescendants()
            .SelectMany(go => go.GetComponentList())
            .ToList();
    }
}
