public class AutoAttackCommand : IAttack
{
    public IAttackable Target { get; }

    public AutoAttackCommand(IAttackable target)
    {
        Target = target;
    }
}