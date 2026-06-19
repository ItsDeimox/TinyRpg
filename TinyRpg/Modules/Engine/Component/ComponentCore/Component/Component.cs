internal abstract class Component : IComponent
{
    public Node? Node { get; private set; }

    protected Component() { }

    public virtual void OnStart() { }

    public virtual void OnCommandInput(CommandInput commandInput) { }

    public void AddComponent(IComponent component)
    {
        Node?.AddComponent(component);
    }

    public T? GetComponent<T>() where T : IComponent
    {
        return Node != null
            ? Node.GetComponent<T>()
            : default;
    }

    public T? GetComponentInChildren<T>() where T : IComponent
    {
        return Node != null
            ? Node.GetComponentInChildren<T>()
            : default;
    }

    public List<T>? GetComponents<T>() where T : IComponent
    {
        return Node != null
            ? Node.GetComponents<T>()
            : default;
    }

    public T? GetComponentInParent<T>() where T : class, IComponent
    {
        return Node?.GetParent()?.GetComponent<T>();
    }

    public List<T>? GetComponentsInParent<T>() where T : IComponent
    {
        return Node?.GetParent()?.GetComponents<T>();
    }

    public void RemoveComponent<T>()
    {
        Node?.RemoveComponent<T>();
    }

    public void SetNode(Node node)
    {
        Node = node;
    }
}
