using UniRx;

public interface IUnitProducer
{
    IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
    void Cancel(int index);
}