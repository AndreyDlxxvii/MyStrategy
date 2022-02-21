using System;
using Zenject;

public class PatrolUnitCommandCommandCreator : CommandCreatorBase<IPatrol>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IPatrol> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new UnitPatrol()));
    }
}