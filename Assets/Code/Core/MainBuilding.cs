using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Outline Contour => _outline;

    [SerializeField] private GameObject _prefabUnit;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private float _health = 1000f;
    [SerializeField] private Sprite _icon;

    private Outline _outline;
    
    private float _maxHealth = 1000f;

    private void Start()
    {
        _outline = GetComponent<Outline>();
    }

    public void CreateUnit()
    {
        Instantiate(_prefabUnit, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)),
            Quaternion.identity, _parentTransform);
    }
}
