interface IScene
{
    event Action? OnSceneStart;
    event Action<INode>? OnNodeAdded;
    event Action<INode>? OnNodeRemoved;

    void OnStart();

    void OnCommandInput(CommandInput commandInput);

    void AddNode(INode node);

    void AddNodes(List<INode> nodes);

    void RemoveNode(INode node);

    bool HasNode(INode node);

    INode? GetNode(string name);

    List<INode> GetChildren();

    List<INode> GetDescendants();

    List<IComponent> GetComponentList();
}
