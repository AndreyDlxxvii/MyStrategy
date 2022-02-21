using UnityEngine;
using Random = UnityEngine.Random;

public class MainBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Contour Outline => _contour;
    
    [SerializeField] private float _health = 1000f;
    [SerializeField] private Sprite _icon;

    private float _contourWidht;
    private Contour _contour;
    private float _maxHealth = 1000f;

    private void Awake()
    {
        _contour = GetComponent<Contour>();
    }
}
