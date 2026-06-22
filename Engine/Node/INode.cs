public interface INode
{
    event Action<IComponent>? OnComponentAdded;
    event Action<IComponent>? OnComponentRemoved;
    event Action<INode>? OnNodeAdded;

    string Name { get; set; }

    Scene? GetScene();

    void SetScene(Scene? scene);

    void AddComponent(IComponent component);

    void AddNode(INode Node);

    T? GetComponent<T>();

    List<T> GetComponents<T>();

    List<IComponent> GetComponentList();

    void RemoveComponent<T>();

    INode? GetChild(int index);

    INode? GetChildByName(string name);

    INode? GetParent();

    void SetParent(INode parent);

    List<INode> GetChildren();

    List<INode> GetDescendants();

    T? GetComponentInChildren<T>();

    List<T> GetComponentsInChildren<T>();

    List<IComponent> GetComponentListInChildren();

    List<T> GetComponentsInDescendants<T>();

    List<IComponent> GetComponentListInDescendats();
}
