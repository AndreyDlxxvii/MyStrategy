using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnit : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Contour Outline => _contour;
    
    [SerializeField] private float _health = 50f;
    [SerializeField] private Sprite _icon;
    
    private float _contourWidht;
    private Contour _contour;
    private float _maxHealth = 50f;
    
    
    private void Awake()
    {
        _contour = GetComponent<Contour>();
    }
}
