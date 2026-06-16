internal interface IConsumable
{
    event Action<GameObject?, int>? OnConsume;
    event Action<int>? OnAddStack;

    string Name { get; set; }

    int GetStack();

    int GetMaxStack();

    bool Consume(GameObject? user = null, int amount = 1);

    bool AddStack(int amount = 1);
}
