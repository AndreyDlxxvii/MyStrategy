using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrol>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    public override async Task ExecuteSpecificCommand(IPatrol command)
    {
        var point1 = command.From;
        var point2 = command.To;
        while (true)
        {
            GetComponent<NavMeshAgent>().destination = point2;
            _animator
                .SetTrigger("Walk");
            _stopCommandExecutor.CancellationToken = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommandExecutor.CancellationToken.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
                break;
            }

            var temp = point1;
            point1 = point2;
            point2 = temp;
        }
        _stopCommandExecutor.CancellationToken = null;
        _animator.SetTrigger("Idle");
    }
}