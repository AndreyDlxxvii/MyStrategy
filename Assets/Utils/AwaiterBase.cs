using System;

public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
{
    private bool _isCompleted;
    private Action _continue;
    private TAwaited _awaited;
    
    public TAwaited GetResult() => _awaited;
    
    public bool IsCompleted => _isCompleted;

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            _continue = continuation;
        }
    }
    
    protected void onWaitFinish(TAwaited result)
    {
        _awaited = result;
        _isCompleted = true;
        _continue?.Invoke();
    }
}