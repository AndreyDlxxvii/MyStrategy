    using UnityEngine;

    public class UnitStop : CommandExecutorBase<IStop>, IStop
    {
        public override void ExecuteSpecificCommand(IStop command)
        {
            Debug.Log("Stop");
        }
    }