public class AttackUnitCommandCommandCreator : CancellableCommandCreatorBase<IAttack, IAttackable>
{
    protected override IAttack createCommand(IAttackable argument) => new UnitAttack(argument);
}