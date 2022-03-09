using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using UniRx;

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

    [Inject]
    private void Init()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        
        var nonBlockedByUiFramesStream = Observable.EveryUpdate()
            .Where(_ => !_eventSystem.IsPointerOverGameObject());
        
        var leftClicksStream = nonBlockedByUiFramesStream
            .Where(_ => Input.GetMouseButtonDown(0));
        var rightClicksStream = nonBlockedByUiFramesStream
            .Where(_ => Input.GetMouseButtonDown(1));
        
        var lmbRays = leftClicksStream
            .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbRays = rightClicksStream
            .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        
        var lmbHitsStream = lmbRays
            .Select(ray => Physics.RaycastAll(ray));
        var rmbHitsStream = rmbRays
            .Select(ray => (ray, Physics.RaycastAll(ray)));
        
        lmbHitsStream.Subscribe(hits =>
        {
            if (IfHit(hits, out _selectable))
            {
                _selectableValue.SetValue(_selectable);
            }
            else
            {
                _selectable = null;
            }
            Outline();
        });
        rmbHitsStream.Subscribe((ray, hits) =>
        {
            if (IfHit<IAttackable>(hits, out var attackable))
            {
                _attackableValue.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
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

    private void Outline()
    {
        
        foreach (var bilds in _selectableBilds)
        {
            bilds.Outline.OutlineWidth = 0f;
        }
        
        if (!_selectableBilds.Contains(_selectable) && _selectable != null)
        {
            _selectableBilds.Add(_selectable);
        }
        else
        {
            _selectableBilds.Clear();
        }
    }
}