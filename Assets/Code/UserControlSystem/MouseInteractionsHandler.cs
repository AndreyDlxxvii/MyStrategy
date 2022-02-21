using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseInteractionsHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;

    private ISelectable _selectable;
    private List<ISelectable> _selectableBilds = new List<ISelectable>();

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
        {
            return;
        }

        _selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();
        _selectableValue.SetValue(_selectable);
        
        if (!_selectableBilds.Contains(_selectable) && _selectable !=null)
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