using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMove>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    public override async Task ExecuteSpecificCommand(IMove command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Walk");
        _stopCommandExecutor.CancellationToken = new CancellationTokenSource();
        try
        {
            await _stop
                .WithCancellation
                (
                    _stopCommandExecutor
                        .CancellationToken
                        .Token
                );
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _stopCommandExecutor.CancellationToken = null;
        _animator.SetTrigger("Idle");
    }
}