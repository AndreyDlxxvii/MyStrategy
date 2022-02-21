using System;
using UnityEngine;
using Zenject;

public class MoveUnitCommandCommandCreator : CommandCreatorBase<IMove>
{
    [Inject] private AssetsContext _context;

    private Action<IMove> _creationCallback;

    [Inject] private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnValue += onNewValue;
    }

    private void onNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new UnitMove(groundClick)));
        _creationCallback = null;
    }

    protected override void classSpecificCommandCreation(Action<IMove> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _creationCallback = null;
    }
}