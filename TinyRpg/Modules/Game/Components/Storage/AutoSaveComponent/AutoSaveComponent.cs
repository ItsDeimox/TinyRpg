using System.Reflection;

internal class AutoSaveComponent<TComponent, TResource> : Component, ISaveble
    where TComponent : Component
    where TResource : Resource
{
    private readonly string _path;

    public AutoSaveComponent(string path)
    {
        _path = path;
    }

    public void OnLoad(EngineStorage engineStorage)
    {
        Component? component = GetComponent<TComponent>();
        if (component is null)
            return;

        TResource? resource = engineStorage.GetStored<TResource>(_path);
        if (resource is null)
            return;

        FieldInfo? fieldInfo = GetComponentResourceField();
        if (fieldInfo is null)
            return;

        fieldInfo.SetValue(component, resource);
    }

    public void OnSave(EngineStorage engineStorage)
    {
        Resource? componentResource = GetComponentResource();
        if (componentResource is null)
            return;

        engineStorage.Store(_path, componentResource);
    }

    private Resource? GetComponentResource()
    {
        Component? component = GetComponent<TComponent>();
        if (component is null)
            return null;

        FieldInfo? fieldInfo = GetComponentResourceField();
        if (fieldInfo?.GetValue(component) is not TResource resource)
            return null;

        return resource;
    }

    private FieldInfo? GetComponentResourceField()
    {
        FieldInfo[]? fieldInfos = GetComponentFields();
        if (fieldInfos is null)
            return null;

        foreach (FieldInfo field in fieldInfos)
        {
            if (field.GetCustomAttribute<ResourceFieldAttribute>() is null)
                continue;

            if (!typeof(TResource).IsAssignableFrom(field.FieldType))
                continue;

            return field;
        }
        
        return null;
    }

    private FieldInfo[]? GetComponentFields()
    {
        Component? component = GetComponent<TComponent>();
        if (component is null)
            return null;

        Type? type = component?.GetType();
        if (type is null)
            return null;

        return type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic
        );
    }
}
