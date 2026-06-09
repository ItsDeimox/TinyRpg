using System.Reflection;

internal static class AttributeManager
{
    public static bool HaveAttribute<T>(object obj) where T : Attribute
    {
        return obj.GetType().IsDefined(typeof(T), true);
    }

    public static bool HaveAttributeField<T>(object obj) where T : Attribute
    {
        return obj.GetType()
            .GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic)
            .Any(field => field.IsDefined(typeof(T), true));
    }
}
