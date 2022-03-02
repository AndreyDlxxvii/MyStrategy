using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("Chomper")] private GameObject _unitPrefab;
    
    [Inject (Id = "Chomper")] public float ProductTime { get; }
    [Inject (Id = "ChomperSprite")] public Sprite Icon { get; }
    [Inject (Id = "Chomper")] public string UnitName { get; }
    public GameObject UnitPrefab => _unitPrefab;
}