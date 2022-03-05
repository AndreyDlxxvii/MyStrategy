public interface IAttack : ICommand
{
    public IAttackable Target { get; }
}