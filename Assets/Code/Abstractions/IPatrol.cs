using UnityEngine;

public interface IPatrol : ICommand
{
    public Vector3 From { get; }
    public Vector3 To { get; }
}