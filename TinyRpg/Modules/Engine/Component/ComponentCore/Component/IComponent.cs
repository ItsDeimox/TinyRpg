internal interface IComponent
{
    Node? Node { get; }

    void OnStart();

    void OnCommandInput(CommandInput commandInput);

    void AddComponent(IComponent component);

    T? GetComponent<T>() where T : IComponent;

    T? GetComponentInChildren<T>() where T : IComponent;

    List<T>? GetComponents<T>() where T : IComponent;

    T? GetComponentInParent<T>() where T : class, IComponent;

    List<T>? GetComponentsInParent<T>() where T : IComponent;

    void RemoveComponent<T>();

    void SetNode(Node Node);
}
