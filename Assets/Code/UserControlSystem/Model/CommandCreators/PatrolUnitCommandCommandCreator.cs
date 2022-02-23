using System;
using UnityEngine;
using Zenject;

public class PatrolUnitCommandCommandCreator : CancellableCommandCreatorBase<IPatrol, Vector3>
{
    [Inject] private AssetsContext _context;
    [Inject] private SelectableValue _selectable;

    protected override IPatrol createCommand(Vector3 argument) => new UnitPatrol(_selectable.CurrentValue.StartPoint.position, argument);

}