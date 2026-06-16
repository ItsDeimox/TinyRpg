internal interface IBasicStatComponent
{
    event Action<int>? OnValueChanged;
    event Action<int>? OnAddValue;
    event Action<int>? OnSubValue;

    string Name { get; set; }

    int GetValue();

    void AddValue(int amount);

    void SubValue(int amount);
}
