internal interface IGameObject
{
    event Action<IComponent>? OnComponentAdded;
    event Action<IComponent>? OnComponentRemoved;
    event Action<IGameObject>? OnGameObjectAdded;

    string Name { get; set; }

    Scene? GetScene();

    void SetScene(Scene? scene);

    void AddComponent(IComponent component);

    void AddGameObject(IGameObject gameObject);

    T? GetComponent<T>();

    List<T> GetComponents<T>();

    List<IComponent> GetComponentList();

    void RemoveComponent<T>();

    IGameObject? GetChild(int index);

    IGameObject? GetChildByName(string name);

    IGameObject? GetParent();

    void SetParent(IGameObject parent);

    List<IGameObject> GetChildren();

    List<IGameObject> GetDescendants();

    T? GetComponentInChildren<T>();

    List<T> GetComponentsInChildren<T>();

    List<IComponent> GetComponentListInChildren();

    List<T> GetComponentsInDescendants<T>();

    List<IComponent> GetComponentListInDescendats();
}
