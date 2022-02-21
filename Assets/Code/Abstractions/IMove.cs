using UnityEngine;

public interface IMove : ICommand
{
    public Vector3 Target { get; }
}