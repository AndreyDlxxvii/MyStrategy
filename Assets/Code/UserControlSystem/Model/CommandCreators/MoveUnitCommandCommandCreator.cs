using UnityEngine;

public class MoveUnitCommandCommandCreator : CancellableCommandCreatorBase<IMove, Vector3>
{ 
    protected override IMove createCommand(Vector3 argument) => new UnitMove(argument);
}