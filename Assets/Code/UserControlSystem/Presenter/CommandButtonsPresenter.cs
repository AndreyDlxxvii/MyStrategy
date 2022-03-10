using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;

    [Inject] private CommandButtonsModel _model;
    
    private ISelectable _currentSelectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
    }

    private void onSelected(ISelectable selectable)
    {
        _view.Clear();
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
            //_model.OnCommandButtonClicked();
        }
        _currentSelectable = selectable;

        
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }
}
