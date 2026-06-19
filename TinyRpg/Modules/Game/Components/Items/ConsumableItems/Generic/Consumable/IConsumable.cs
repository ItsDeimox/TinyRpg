internal interface IConsumable
{
    event Action<Node?, int>? OnConsume;
    event Action<int>? OnAddStack;

    string Name { get; set; }

    int GetStack();

    int GetMaxStack();

    bool Consume(Node? user = null, int amount = 1);

    bool AddStack(int amount = 1);
}
