using System;
using UnityEngine;
using Zenject;

public class PatrolUnitCommandCommandCreator : CommandCreatorBase<IPatrol>
{
    [Inject] private AssetsContext _context;
    [Inject] private SelectableValue _selectable;

    private Action<IPatrol> _patrolCall;
    
    [Inject] private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnSelected += OnSelect;
    }

    private void OnSelect(Vector3 obj)
    {
        _patrolCall?.Invoke(_context.Inject(new UnitPatrol(_selectable.CurrentValue.StartPoint.position, obj)));
        _patrolCall = null;
    }

    protected override void classSpecificCommandCreation(Action<IPatrol> creationCallback)
    {
        _patrolCall = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _patrolCall = null;
    }
}