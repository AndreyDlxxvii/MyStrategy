using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMove>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;

    public override async void ExecuteSpecificCommand(IMove command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Walk");
        await _stop;
        _animator.SetTrigger("Idle");
    }
}