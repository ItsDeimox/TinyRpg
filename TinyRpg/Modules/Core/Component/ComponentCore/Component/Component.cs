internal abstract class Component : IComponent
{
    public GameObject? GameObject { get; private set; }

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

    public void RemoveComponent<T>()
    {
        GameObject?.RemoveComponent<T>();
    }

    public void SetGameObject(GameObject gameObject)
    {
        GameObject = gameObject;
    }
}
