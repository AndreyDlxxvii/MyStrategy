using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionsHandler : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;
    
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
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .Where(c => c != null)
                .FirstOrDefault();
            _selectableValue.SetValue(selectable);
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
        Outline();
    }

    private void Outline()
    {
        if (!_selectableBilds.Contains(_selectable) && _selectable != null)
        {
            _selectableBilds.Add(_selectable);
        }
        else if (_selectable == null)
        {
            foreach (var bilds in _selectableBilds)
            {
                bilds.Outline.OutlineWidth = 0f;
            }

            _selectableBilds.Clear();
        }
    }
}