using System.Threading.Tasks;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttack>
{
    public override async Task ExecuteSpecificCommand(IAttack command)
    {
        Debug.Log($"{name} is attacking!");
    }
}