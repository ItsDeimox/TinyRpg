public class Scene : IScene
{
    public event Action? OnSceneStart;
    public event Action<INode>? OnNodeAdded;
    public event Action<INode>? OnNodeRemoved;

    private List<INode> _children = new();

    public void OnStart()
    {
        OnSceneStart?.Invoke();

        foreach (var node in GetDescendants())
        {
            ComponentManager.StartComponents(node.GetComponentList());
            node.OnComponentAdded += (IComponent component) => component.OnStart();
        }
    }

    public void OnCommandInput(CommandInput commandInput)
    {
        foreach (var node in _children)
        {
            ComponentManager.RunCommandInputComponents(node.GetComponentList(), commandInput);
        }
    }

    public void AddNode(INode node)
    {
        _children.Add(node);

        node.SetScene(this);

        OnNodeAdded?.Invoke(node);
    }

    public void AddNodes(List<INode> nodes)
    {
        foreach (var node in nodes)
        {
            AddNode(node);
        }
    }

    public void RemoveNode(INode node)
    {
        _children.Remove(node);

        node.SetScene(null);

        OnNodeRemoved?.Invoke(node);
    }

    public bool HasNode(INode node)
    {
        return _children.Contains(node);
    }

    public INode? GetNode(string name)
    {
        return _children.FirstOrDefault(go => go.Name == name);
    }

    public List<INode> GetChildren()
    {
        return _children;
    }

    public List<INode> GetDescendants()
    {
        return _children
            .SelectMany(go => go.GetDescendants())
            .Concat(_children)
            .ToList();
    }

    public List<IComponent> GetComponentList()
    {
        return GetDescendants()
            .SelectMany(go => go.GetComponentList())
            .ToList();
    }
}
