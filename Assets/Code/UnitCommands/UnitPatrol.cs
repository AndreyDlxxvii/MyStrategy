    using UnityEngine;

    public class UnitPatrol : CommandExecutorBase<IPatrol>, IPatrol
    {
        public override void ExecuteSpecificCommand(IPatrol command)
        {
            Debug.Log("Patrol");
        }
    }