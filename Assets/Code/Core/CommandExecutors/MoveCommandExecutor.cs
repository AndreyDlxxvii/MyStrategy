using UnityEngine;

public class MoveCommandExecutor : CommandExecutorBase<IMove>
{
    public override void ExecuteSpecificCommand(IMove command)
    {
        Debug.Log($"{name} is moving!");
    }
}