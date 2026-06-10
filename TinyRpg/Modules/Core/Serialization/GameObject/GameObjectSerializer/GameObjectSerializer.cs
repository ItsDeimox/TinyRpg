using System.Text;
using System.Text.Json;

internal static class GameObjectSerializer
{
    public static SerializableGameObject? GetSerializableGameObject(GameObject gameObject)
    {
        List<SerializableGameObject> serializableGameObjects = GetSerializableGameObjectChildren(gameObject);
        List<SerializableObject> serizableComponents = GetSerializableComponentsFromGameObject(gameObject);

        SerializableGameObject serializableGameObject = new(
            gameObject.Name,
            serizableComponents,
            serializableGameObjects
        );

        return serializableGameObject;
    }

    public static string Serialize(GameObject gameObject)
    {
        SerializableGameObject? serializableGameObject = GetSerializableGameObject(gameObject);
        return JsonSerializer.Serialize(serializableGameObject);
    }

    public static T? Deserialize<T>(string gameObjectJson) where T : GameObject
    {
        return JsonSerializer.Deserialize<T>(gameObjectJson);
    }

    private static List<SerializableObject> GetSerializableComponentsFromGameObject(GameObject gameObject)
    {
        List<IComponent> components = gameObject.GetComponentList();

        List<SerializableObject> serizableComponents = new();

        foreach (IComponent component in components)
        {
            if (!AttributeManager.HaveAttribute<SerializableAttribute>(component)) continue;

            SerializableObject serializableObject = Serializer.GetSerializableObject(component);

            serizableComponents.Add(serializableObject);
        }

        return serizableComponents;
    }

    private static List<SerializableGameObject> GetSerializableGameObjectChildren(GameObject gameObject)
    {
        List<IGameObject> gameObjects = gameObject.GetChildren();

        if (gameObjects.Count == 0) return new();

        List<SerializableGameObject> serializableGameObjects = new();

        foreach (IGameObject go in gameObjects)
        {
            SerializableGameObject? serializableGameObject = GetSerializableGameObject((GameObject)go);

            if (serializableGameObject == null) continue;

            serializableGameObjects.Add(serializableGameObject);
        }

        return serializableGameObjects;
    }
}
