internal class Inventory : Component, IInventory
{
    public event Action<IConsumable>? OnAddItem;
    public event Action<IConsumable>? OnRemoveItem;

    private List<IConsumable> _items;

    public Inventory(List<IConsumable>? initItems = null)
    {
        _items = initItems ?? new();
    }

    public T? GetItem<T>(string itemName)
    {
        foreach (var item in _items)
        {
            if (item.Name.ToLower() == itemName.ToLower()) return (T) item;
        }

        return default;
    }

    public List<IConsumable> GetItems()
    {
        return _items;
    }

    public bool AddItem(IConsumable item)
    {
        if (HaveItem(item)) return false;

        _items.Add(item);

        OnAddItem?.Invoke(item);

        return true;
    }

    public bool RemoveItem(string itemName)
    {
        IConsumable? item = GetItem<IConsumable>(itemName);

        if (item == null) return false;

        _items.Remove(item);
        OnRemoveItem?.Invoke(item);

        return true;
    }

    private bool HaveItem(IConsumable item)
    {
        return GetItem<IConsumable>(item.Name) != null;
    }
}
