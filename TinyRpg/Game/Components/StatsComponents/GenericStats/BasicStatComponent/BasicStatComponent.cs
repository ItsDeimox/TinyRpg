internal class BasicStatComponent : Component, IBasicStatComponent
{
    public event Action<int>? OnValueChanged;
    public event Action<int>? OnAddValue;
    public event Action<int>? OnSubValue;

    public string Name { get; set; }

    private int _value { get; set; }

    public BasicStatComponent(string name = "Basic Stats", int initialValue = 0)
    {
        Name = name;
        _value = initialValue;
    }

    public int GetValue()
    {
        return _value;
    }

    public void AddValue(int amount)
    {
        _value += amount;

        OnAddValue?.Invoke(amount);
        OnValueChanged?.Invoke(_value);
    }

    public void SubValue(int amount)
    {
        _value -= amount;
        OnSubValue?.Invoke(amount);
        OnValueChanged?.Invoke(_value);
    }

    public void SetValue(int value)
    {
        _value = value;
        OnValueChanged?.Invoke(_value);
    }
}
