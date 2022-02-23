using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionsHandler : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private AttackableValue _attackableValue;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;

    private ISelectable _selectable;
    private List<ISelectable> _selectableBilds = new List<ISelectable>();

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            return;
        

        if (_eventSystem.IsPointerOverGameObject())
            return;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        
        if (Input.GetMouseButtonUp(0))
        {
            if (IfHit<ISelectable>(hits, out var selectable))
            {
                _selectableValue.SetValue(selectable);
                Outline(selectable);
            }
        }
        else
        {
            if (IfHit<IAttackable>(hits, out var attackable))
            {
                _attackableValue.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray,out var wayPoint))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * wayPoint);
            }
        }
    }

    private bool IfHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }

        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();

        return result != default;
    }

    private void Outline(ISelectable value)
    {
        if (!_selectableBilds.Contains(value) && value != null)
        {
            _selectableBilds.Add(value);
        }
        else if (value == null)
        {
            foreach (var bilds in _selectableBilds)
            {
                bilds.Outline.OutlineWidth = 0f;
            }
        
            _selectableBilds.Clear();
        }
    }
}