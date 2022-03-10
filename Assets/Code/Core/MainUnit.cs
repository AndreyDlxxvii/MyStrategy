using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer, IAutomaticAttacker
{
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommand;
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _visionRaidus = 8f;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public int Damage => _damage;
    
    public Transform StartPoint { get; private set; }
    public float VisionRadius => _visionRaidus;
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

    private void Update()
    {
        StartPoint = transform;
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
            _animator.SetTrigger("PlayerDead");
            Invoke(nameof(destroy), 1f);
        }
    }
    private async void destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new UnitStop());
        Destroy(gameObject);
    }
}
