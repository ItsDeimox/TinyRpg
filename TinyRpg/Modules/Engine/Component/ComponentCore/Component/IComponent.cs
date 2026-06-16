internal interface IComponent
{
    GameObject? GameObject { get; }

    void OnStart();

    void OnCommandInput(CommandInput commandInput);

    void AddComponent(IComponent component);

    T? GetComponent<T>() where T : IComponent;

    T? GetComponentInChildren<T>() where T : IComponent;

    List<T>? GetComponents<T>() where T : IComponent;

    void RemoveComponent<T>();

    void SetGameObject(GameObject gameObject);
}
