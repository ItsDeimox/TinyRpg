internal abstract class Node : INode
{
    public event Action<IComponent>? OnComponentAdded;
    public event Action<IComponent>? OnComponentRemoved;
    public event Action<INode>? OnNodeAdded;

    public string Name { get; set; }

    private INode? _parent;
    private List<INode> _children = new();
    private List<IComponent> _components = new();

    private Scene? _scene { get; set; } = new();

    protected Node() : this("Node") { }

    public Node(string name = "Node", INode? parent = null)
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
        component.SetNode(this);

        _components.Add(component);

        OnComponentAdded?.Invoke(component);
    }

    public void AddNode(INode Node)
    {
        _children.Add(Node);

        Node.SetParent(this);

        OnNodeAdded?.Invoke(Node);
    }

    public T? GetComponent<T>()
    {
        return _components.OfType<T>().FirstOrDefault();
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

    public List<INode> GetNode(string name)
    {
        return _children.Where(c => c.Name == name).ToList();
    }

    public List<INode> GetChildren()
    {
        return _children;
    }

    public List<INode> GetDescendants()
    {
        return _children
            .SelectMany(c => c.GetDescendants())
            .Concat(_children)
            .ToList();
    }

    public INode? GetChild(int index)
    {
        return _children.ElementAtOrDefault(index);
    }

    public INode? GetChildByName(string name)
    {
        return _children.FirstOrDefault(c => c.Name == name);
    }

    public INode? GetParent()
    {
        return _parent;
    }

    public void SetParent(INode parent)
    {
        _parent = parent;
    }

    public T? GetComponentInChildren<T>()
    {
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
