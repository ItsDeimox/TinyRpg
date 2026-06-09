internal class AddDamageAmuletCommand() : CommandInputComponent("add_damage_amulet", "Add an amullet that adds Damage to your character")
{
    public override void OnCommand(string[]? args = null)
    {
        base.OnCommand(args);
        
        var damageAmulet = new DamageAmulet();

        AddComponent(damageAmulet);

        damageAmulet.Equip();

        Console.WriteLine("\nYou have equipped a damage amulet to your character!");
        Console.WriteLine("Your damage has been increased by 10 points.");
    }
}
