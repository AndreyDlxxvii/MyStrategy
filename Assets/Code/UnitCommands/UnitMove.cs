    using UnityEngine;

    public class UnitMove : CommandExecutorBase<IMove>, IMove
    {
        public override void ExecuteSpecificCommand(IMove command)
        {
            Debug.Log("Move");
        }
    }