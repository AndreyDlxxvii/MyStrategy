using System;
using Zenject;

public class AttackUnitCommandCommandCreator : CommandCreatorBase<IAttack>
{
    [Inject] private AssetsContext _context;
    protected override void classSpecificCommandCreation(Action<IAttack> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new UnitAttack()));
    }
}