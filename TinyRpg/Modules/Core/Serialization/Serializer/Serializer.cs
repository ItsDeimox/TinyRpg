using System.Reflection;
using System.Text.Json;

internal static class Serializer
{
    public static SerializableObject GetSerializableObject(object obj)
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

            serializableObject.Fields.Add(serializableField);
        }

        return serializableObject;
    }

    public static string Serialize(object obj)
    {
        SerializableObject serializableObject = GetSerializableObject(obj);
        return JsonSerializer.Serialize(serializableObject);
    }

    public static T? Deserialize<T>(string json)
    {
        SerializableObject? serializableObject = JsonSerializer.Deserialize<SerializableObject>(json);
        if (serializableObject == null) return default;

        Type? type = Type.GetType(serializableObject.TypeName);
        if (type == null) return default;

        object? instance = Activator.CreateInstance(type);
        if (instance is not T validInstance) return default;

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic
        );

        foreach (var field in fields)
        {
            var serializeField = field.GetCustomAttribute<SerializeFieldAttribute>();
            if (serializeField == null) continue;

            SerializableField? serializableField = 
                serializableObject
                .Fields
                .FirstOrDefault(sf => sf.Id == serializeField.Id);
            if (serializableField == null) continue;
            if (serializableField.Value is not JsonElement element) continue;

            Type? targetType = Type.GetType(serializableField.Type);
            if (targetType == null) continue;

            object? value = JsonSerializer.Deserialize(element.GetRawText(), targetType);
            if (value == null) continue;

            field.SetValue(instance, value);
        }

        return validInstance;
    }
}
