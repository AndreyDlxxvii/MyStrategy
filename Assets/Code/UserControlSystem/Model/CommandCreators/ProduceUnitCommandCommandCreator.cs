using System;
using Zenject;

public class ProduceUnitCommandCommandCreator : CancellableCommandCreatorBase<IProduceUnitCommand, ISelectable>
{
    protected override IProduceUnitCommand createCommand(ISelectable argument) => new ProduceUnitCommand();
  
}