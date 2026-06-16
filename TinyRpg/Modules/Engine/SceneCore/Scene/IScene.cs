internal interface IScene
{
    event Action? OnSceneStart;
    event Action<IGameObject>? OnGameObjectAdded;
    event Action<IGameObject>? OnGameObjectRemoved;

    void OnStart();

    void OnCommandInput(CommandInput commandInput);

    void AddGameObject(IGameObject gameObject);

    void AddGameObjects(List<IGameObject> gameObjects);

    void RemoveGameObject(IGameObject gameObject);

    bool HasGameObject(IGameObject gameObject);

    IGameObject? GetGameObject(string name);

    List<IGameObject> GetChildren();

    List<IGameObject> GetDescendants();

    List<IComponent> GetComponentList();
}
