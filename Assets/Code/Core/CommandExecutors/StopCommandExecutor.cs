using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStop>
{

    public override void ExecuteSpecificCommand(IStop command)
    {
        Debug.Log($"{name} has stopped!");
    }
}