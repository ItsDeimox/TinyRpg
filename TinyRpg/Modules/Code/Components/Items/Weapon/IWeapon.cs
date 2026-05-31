internal interface IWeapon
{
    event Action<int>? OnAttack;

    int Damage { get; set; }

    void Attack();
}
