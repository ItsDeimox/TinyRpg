internal static class ComponentManager
{
    public static void StartComponents(List<IComponent> components)
    {
        foreach (var component in components.ToList())
        {
            component.OnStart();
        }
    }

    public static void RunCommandInputComponents(List<IComponent> components, CommandInput commandInput)
    {
        foreach (var component in components.ToList())
        {
            component.OnCommandInput(commandInput);
        }
    }
}
