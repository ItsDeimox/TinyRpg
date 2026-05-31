internal interface IUpgrader
{
    event Action? OnUpgrade;

    void Upgrade();
}
