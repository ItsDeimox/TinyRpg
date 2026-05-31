internal class Sword : Weapon
{
    public Sword(int damage = 5) : base(damage)
    {
        Damage = damage;
    }

    public override void Attack()
    {
        base.Attack();
    }
}
