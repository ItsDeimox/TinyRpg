using System.Text.Json;

internal static class GameObjectSerializer
{
    public static object? Serialize(GameObject gameObject)
    {
        List<IComponent> components = gameObject.GetComponentList();

        if (components == null || components.Count == 0) return default;

        List<string> serizaliedComponents = new();

        foreach (IComponent component in components)
        {
            if (!AttributeManager.HaveAttribute<SerializableAttribute>(component)) continue;

            string serializedComponent = Serializer.Serialize(component);
            serizaliedComponents.Add(serializedComponent);
        }

        SerializableGameObject serializableGameObject = new(
            gameObject.Name,
            serizaliedComponents
        );

        string json = JsonSerializer.Serialize(serializableGameObject);

        return json;
    }
}
