using UnityEngine;
using Random = UnityEngine.Random;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    
    public Transform StartPoint { get; }
    public Sprite Icon => _icon;
    public Contour Outline => _contour;
    
    [SerializeField] private float _health = 1000f;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _unitsParent;

    private float _contourWidht;
    private Contour _contour;
    private float _maxHealth = 1000f;

    private void Awake()
    {
        _contour = GetComponent<Contour>();
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        // Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), 
        //     Quaternion.identity, _unitsParent);
    }
}
