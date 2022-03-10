using UnityEngine;

public interface IProduceUnitCommand : ICommand, IIconHolder
{
    GameObject UnitPrefab { get; }
    float ProductTime { get; }
    string UnitName { get; }
    
}