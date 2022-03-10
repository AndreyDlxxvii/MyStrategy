using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<ISetRallyPointCommand> _spawnPointCommandExecutorBase;
    [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
    
    public ICommand CurrentCommand => default;
    public async Task EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
        await _spawnPointCommandExecutorBase.TryExecuteCommand(command);
    }

    public void Clear()
    {
    }
}