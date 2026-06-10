using System.Text.Json;

internal static class SceneSerializer
{
    public static SerializableScene? GetSerializableScene(Scene scene)
    {
        List<IGameObject> gameObjects = scene.GetChildren();

        if (gameObjects.Count == 0) return default;

        List<SerializableGameObject> serializableGameObjects = new();

        foreach (var gameObject in gameObjects)
        {
            SerializableGameObject? serializableGameObject = GameObjectSerializer.GetSerializableGameObject((GameObject)gameObject);
            if (serializableGameObject == null) continue;
            
            serializableGameObjects.Add(serializableGameObject);
        }

        SerializableScene serializableScene = new(scene.GetType().ToString(), serializableGameObjects);

        return serializableScene;
    }

    public static string? Serialize(Scene scene)
    {
        SerializableScene? serializableScene = GetSerializableScene(scene);
        return JsonSerializer.Serialize(serializableScene);
    }

    public static T? Deserialize<T>(string sceneJson) where T : Scene
    {
        return JsonSerializer.Deserialize<T>(sceneJson);
    }
}
