using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttack>
{
    public override void ExecuteSpecificCommand(IAttack command)
    {
        Debug.Log($"{name} is attacking!");
    }
}