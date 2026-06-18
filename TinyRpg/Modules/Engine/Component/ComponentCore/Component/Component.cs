internal abstract class Component : IComponent
{
    public GameObject? GameObject { get; private set; }

    protected Component() { }

    public virtual void OnStart() { }

    public virtual void OnCommandInput(CommandInput commandInput) { }

    public void AddComponent(IComponent component)
    {
        GameObject?.AddComponent(component);
    }

    public T? GetComponent<T>() where T : IComponent
    {
        return GameObject != null
            ? GameObject.GetComponent<T>()
            : default;
    }

    public T? GetComponentInChildren<T>() where T : IComponent
    {
        return GameObject != null
            ? GameObject.GetComponentInChildren<T>()
            : default;
    }

    public List<T>? GetComponents<T>() where T : IComponent
    {
        return GameObject != null
            ? GameObject.GetComponents<T>()
            : default;
    }

    public T? GetComponentInParent<T>() where T : class, IComponent
    {
        return GameObject?.GetParent()?.GetComponent<T>();
    }

    public List<T>? GetComponentsInParent<T>() where T : IComponent
    {
        return GameObject?.GetParent()?.GetComponents<T>();
    }

    public void RemoveComponent<T>()
    {
        GameObject?.RemoveComponent<T>();
    }

    public void SetGameObject(GameObject gameObject)
    {
        GameObject = gameObject;
    }
}
