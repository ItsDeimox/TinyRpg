internal abstract class GameObject : IGameObject
{
    public event Action<IComponent>? OnComponentAdded;
    public event Action<IComponent>? OnComponentRemoved;
    public event Action<IGameObject>? OnGameObjectAdded;

    public string Name { get; set; }

    private IGameObject? _parent;
    private List<IGameObject> _children = new();
    private List<IComponent> _components = new();

    private Scene? _scene { get; set; } = new();

    public GameObject(string name = "GameObject", IGameObject? parent = null)
    {
        Name = name;
        _parent = parent;
    }

    public Scene? GetScene()
    {
        return _scene;
    }

    public void SetScene(Scene? scene)
    {
        _scene = scene;
    }

    public void AddComponent(IComponent component)
    {
        component.SetGameObject(this);

        _components.Add(component);

        OnComponentAdded?.Invoke(component);
    }

    public void AddGameObject(IGameObject gameObject)
    {
        _children.Add(gameObject);

        gameObject.SetParent(this);
        
        _scene?.AddGameObject(gameObject);

        OnGameObjectAdded?.Invoke(gameObject);
    }

    public T? GetComponent<T>()
    {
        foreach (var component in _components)
        {
            if (component is T) return (T) component;
        }

        return default;
    }

    public void RemoveComponent<T>()
    {
        foreach(var component in _components)
        {
            if (component is not T) continue;

            _components.Remove(component);
            OnComponentRemoved?.Invoke(component);

            break;
        }
    }

    public List<T> GetComponents<T>()
    {
        return _components.Where(c => c is T).Select(c => (T)c).ToList();
    }

    public List<IComponent> GetComponentList()
    {
        return _components;
    }

    public List<IGameObject> GetGameObject(string name)
    {
        return _children.Where(c => c.Name == name).ToList();
    }

    public List<IGameObject> GetChildren()
    {
        return _children;
    }

    public List<IGameObject> GetDescendants()
    {
        return _children
            .SelectMany(c => c
            .GetDescendants())
            .Concat(_children)
            .ToList();
    }

    public IGameObject? GetChild(int index)
    {
        return _children.ElementAtOrDefault(index);
    }

    public IGameObject? GetChildByName(string name)
    {
        return _children.FirstOrDefault(c => c.Name == name);
    }

    public IGameObject? GetParent()
    {
        return _parent;
    }

    public void SetParent(IGameObject parent)
    {
        _parent = parent;
    }

    public T? GetComponentInChildren<T>()
    {
        T? component = GetComponent<T>();

        if (component != null) return component;

        return GetChildren()
            .SelectMany(c => c.GetComponents<T>())
            .FirstOrDefault();
    }

    public List<T> GetComponentsInChildren<T>()
    {
        return GetChildren()
            .SelectMany(c => c.GetComponents<T>())
            .ToList();
    }

    public List<IComponent> GetComponentListInChildren()
    {
        return GetChildren()
            .SelectMany(c => c.GetComponentList())
            .ToList();
    }

    public List<T> GetComponentsInDescendants<T>()
    {
        return GetDescendants()
            .SelectMany(c => c.GetComponents<T>())
            .ToList();
    }

    public List<IComponent> GetComponentListInDescendats()
    {
        return GetDescendants()
            .SelectMany(c => c.GetComponentList())
            .ToList();
    }
}
