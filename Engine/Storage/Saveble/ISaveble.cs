public interface ISaveble
{
    void OnSave(Storage engineStorage);

    void OnLoad(Storage engineStorage);
}
