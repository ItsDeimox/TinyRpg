internal class Weapon : Component, IWeapon
{
    public event Action<int>? OnAttack;

    public int Damage { get; set; }

    public Weapon(int damage = 1)
    {
        Damage = damage;
    }

    public virtual void Attack()
    {
        Console.WriteLine($"Attacked dealing {Damage} damage");
        OnAttack?.Invoke(Damage);
    }
}
