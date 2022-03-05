using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public Transform StartPoint { get; }
    public Sprite Icon => _icon;
    public Contour Outline => _contour;
    
    public Vector3 RallyPoint { get; set; }
    
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
    
    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

    }

    // public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
    // {
    //     // Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), 
    //     //     Quaternion.identity, _unitsParent);
    // }
}
