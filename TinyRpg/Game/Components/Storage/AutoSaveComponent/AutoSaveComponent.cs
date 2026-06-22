using System.Reflection;

internal class AutoSaveComponent<TComponent, TResource>(string path) : Component, ISaveble
    where TComponent : Component
    where TResource : Resource
{
    private readonly string _path = path;

    public void OnLoad(Storage storage)
    {
        Component? component = GetComponent<TComponent>();
        if (component is null)
            return;

        TResource? resource = storage.GetStored<TResource>(_path);
        if (resource is null)
            return;

        PropertyInfo? PropertyInfo = GetComponentResourceProperty();
        if (PropertyInfo is null)
            return;

        PropertyInfo.SetValue(component, resource);
    }

    public void OnSave(Storage storage)
    {
        Resource? componentResource = GetComponentResource();
        if (componentResource is null)
            return;

        storage.Store(_path, componentResource);
    }

    private Resource? GetComponentResource()
    {
        Component? component = GetComponent<TComponent>();
        if (component is null)
            return null;

        PropertyInfo? propertyInfo = GetComponentResourceProperty();
        if (propertyInfo?.GetValue(component) is not TResource resource)
            return null;

        return resource;
    }

    private PropertyInfo? GetComponentResourceProperty()
    {
        PropertyInfo[]? propertyInfos = GetComponentProperties();
        if (propertyInfos is null)
            return null;

        foreach (PropertyInfo property in propertyInfos)
        {
            bool hasAttribute = property.IsDefined(typeof(ResourceFieldAttribute), true);

            if (!hasAttribute)
                continue;

            return property;
        }
        
        return null;
    }

    private PropertyInfo[]? GetComponentProperties()
    {
        Component? component = GetComponent<TComponent>();

        return component?.GetType().GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic
        );
    }
}
