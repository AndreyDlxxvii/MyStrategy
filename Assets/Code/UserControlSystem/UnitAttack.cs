public class UnitAttack : IAttack
{
    public IAttackable Target { get; }

    public UnitAttack(IAttackable target)
    {
        Target = target;
    }
}