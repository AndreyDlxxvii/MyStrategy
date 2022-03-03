using System.Threading.Tasks;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrol>
{
    public override async Task ExecuteSpecificCommand(IPatrol command)
    {
        Debug.Log($"{name} patroling!");
    }
}