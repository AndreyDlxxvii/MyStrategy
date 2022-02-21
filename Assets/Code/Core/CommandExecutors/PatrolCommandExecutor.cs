using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrol>
{
    public override void ExecuteSpecificCommand(IPatrol command)
    {
        Debug.Log($"{name} patroling!");
    }
}