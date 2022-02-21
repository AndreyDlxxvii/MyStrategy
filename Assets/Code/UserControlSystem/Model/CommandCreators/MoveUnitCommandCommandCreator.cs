using System;
using Zenject;

public class MovelUnitCommandCommandCreator : CommandCreatorBase<IMove>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IMove> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new UnitMove()));
    }
}