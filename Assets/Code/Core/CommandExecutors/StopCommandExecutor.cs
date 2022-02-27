using System.Threading;

public class StopCommandExecutor : CommandExecutorBase<IStop>
{
    public CancellationTokenSource CancellationToken { get; set; }
    public override void ExecuteSpecificCommand(IStop command)
    {
        CancellationToken?.Cancel();
    }
}