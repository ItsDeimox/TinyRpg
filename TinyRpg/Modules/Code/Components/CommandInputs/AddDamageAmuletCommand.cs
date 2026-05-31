internal class AddDamageAmuletCommand() : CommandInputComponent("add_damage_amulet", "Add an amullet that adds Damage to your character")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);
        
        AddComponent(new DamageAmulet());
    }
}
