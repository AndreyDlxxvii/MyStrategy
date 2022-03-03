using System.Threading.Tasks;

public interface ICommandsQueue
{
    Task EnqueueCommand(object command);
    void Clear();
}