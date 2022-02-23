using System;
using Zenject;

public class AttackUnitCommandCommandCreator : CommandCreatorBase<IAttack>
{
    [Inject] private AssetsContext _context;

    private Action<IAttack> _attackCall;
    
    [Inject] private void Init(AttackableValue _attackableValue)
    {
        _attackableValue.OnSelected += Onselected;
    }

    private void Onselected(IAttackable obj)
    {
        _attackCall?.Invoke(_context.Inject(new UnitAttack(obj)));
        _attackCall = null;
    }

    protected override void classSpecificCommandCreation(Action<IAttack> creationCallback)
    {
        _attackCall = creationCallback;
    }
    
    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _attackCall = null;
    }

}