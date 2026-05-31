internal class Scene : IScene
{
    public event Action? OnSceneStart;
    public event Action<IGameObject>? OnGameObjectAdded;
    public event Action<IGameObject>? OnGameObjectRemoved;

    private List<IGameObject> _gameObjects = new();

    public void OnStart()
    {
        OnSceneStart?.Invoke();

        foreach (var gameObject in _gameObjects)
        {
            ComponentManager.StartComponents(gameObject.GetComponentList());
            gameObject.OnComponentAdded += (IComponent component) => component.OnStart();
        }
    }

    public void OnCommandInput(CommandInput commandInput)
    {
        foreach (var gameObject in _gameObjects)
        {
            ComponentManager.RunCommandInputComponents(gameObject.GetComponentList(), commandInput);
        }
    }

    public void AddGameObject(IGameObject gameObject)
    {
        _gameObjects.Add(gameObject);

        gameObject.SetScene(this);

        OnGameObjectAdded?.Invoke(gameObject);
    }

    public void RemoveGameObject(IGameObject gameObject)
    {
        _gameObjects.Remove(gameObject);

        gameObject.SetScene(null);

        OnGameObjectRemoved?.Invoke(gameObject);
    }

    public bool HasGameObject(IGameObject gameObject)
    {
        return _gameObjects.Contains(gameObject);
    }

    public IGameObject? GetGameObject(string name)
    {
        return _gameObjects.FirstOrDefault(go => go.Name == name);
    }
}
