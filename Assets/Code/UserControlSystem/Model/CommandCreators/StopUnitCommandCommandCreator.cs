using System;
using Zenject;

public class StopUnitCommandCommandCreator : CommandCreatorBase<IStop>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IStop> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new UnitStop()));
    }
}