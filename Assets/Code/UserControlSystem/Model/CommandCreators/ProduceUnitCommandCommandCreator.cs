using System;
using Zenject;

public class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        var t = new ProduceUnitCommand();
        creationCallback?.Invoke(_context.Inject(t));
    }
}