using System.Reflection;
using System.Text.Json;

internal static class Serializer
{
    public static string Serialize(object obj)
    {
        Type componentType = obj.GetType();

        FieldInfo[] fields = componentType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic
        );

        SerializableObject serializableObject = new(componentType.AssemblyQualifiedName!);

        foreach (var field in fields)
        {
            SerializeFieldAttribute? serializeField = field.GetCustomAttribute<SerializeFieldAttribute>();
            if (serializeField == null) continue;

            object? fieldValue = field.GetValue(obj);
            if (fieldValue == null) continue;

            string? fieldType = field.FieldType.AssemblyQualifiedName;
            if (fieldType == null) continue;

            SerializableField serializableField = new(serializeField.Id, fieldValue, fieldType);

            serializableObject.Fields.Add(serializeField.Id, serializableField);
        }

        string json = JsonSerializer.Serialize(serializableObject);

        return json;
    }

    public static T? Deserialize<T>(string json)
    {
        SerializableObject? serializableObject = JsonSerializer.Deserialize<SerializableObject>(json);
        if (serializableObject == null) return default;

        Type? type = Type.GetType(serializableObject.TypeName);
        if (type == null) return default;

        object? instance = Activator.CreateInstance(type);
        if (instance == null) return default;

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic
        );

        foreach (var field in fields)
        {
            var serializeField = field.GetCustomAttribute<SerializeFieldAttribute>();
            if (serializeField == null) continue;

            if (!serializableObject.Fields.TryGetValue(
                serializeField.Id,
                out var serializableField
            )) continue;

            Type? targetType = Type.GetType(serializableField.Type);
            if (targetType == null) continue;

            if (serializableField.Value is not JsonElement element) continue;

            object? value = JsonSerializer.Deserialize(element.GetRawText(),targetType);
            if (value == null) continue;

            field.SetValue(instance, value);
        }

        if (instance is not T validInstance) return default;

        return validInstance;
    }
}
