internal class Consumable : Component, IConsumable
{
    public event Action<GameObject?, int>? OnConsume;
    public event Action<int>? OnAddStack;

    public string Name { get; set; }

    private int _maxStack;
    private int _currentStack;

    public Consumable(string name = "Consumable", int maxStack = 1)
    {
        Name = name;
        _maxStack = maxStack;
    }

    public int GetStack()
    {
        return _currentStack;
    }

    public int GetMaxStack()
    {
        return _maxStack;
    }

    public virtual bool Consume(GameObject? user = null, int amount = 1)
    {
        if (!CanConsume(amount)) return false;

        _currentStack -= amount;
        _currentStack = Math.Max(_currentStack, 0);

        OnConsume?.Invoke(user, amount);

        return true;
    }

    public bool AddStack(int amount = 1)
    {
        if (!CanAddStack(amount)) return false;

        _currentStack += amount;
        _currentStack = Math.Min(_currentStack, _maxStack);

        OnAddStack?.Invoke(amount);

        return true;
    }

    private bool CanConsume(int amount)
    {
        return _currentStack - amount >= 0;
    }

    private bool CanAddStack(int amount)
    {
        return _currentStack + amount <= _maxStack;
    }
}
