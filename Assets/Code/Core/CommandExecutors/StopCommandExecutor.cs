using System.Threading;
using System.Threading.Tasks;

public class StopCommandExecutor : CommandExecutorBase<IStop>
{
    public CancellationTokenSource CancellationToken { get; set; }
    public override async Task ExecuteSpecificCommand(IStop command)
    {
        CancellationToken?.Cancel();
    }
}