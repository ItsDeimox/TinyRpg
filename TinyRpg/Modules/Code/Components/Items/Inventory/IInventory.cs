internal interface IInventory
{
    event Action<IConsumable>? OnAddItem;
    event Action<IConsumable>? OnRemoveItem;

    T? GetItem<T>(string itemName);

    List<IConsumable> GetItems();

    bool AddItem(IConsumable item);

    bool RemoveItem(string itemName);
}
