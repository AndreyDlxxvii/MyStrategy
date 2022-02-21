using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _assetsContext;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        
        _view.Clear();
        
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void onButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_assetsContext.Inject(new ProduceUnitCommandHeir()));
            return;
        }

        var unitAttack = commandExecutor as CommandExecutorBase<IAttack>;
        if (unitAttack != null)
        {
            unitAttack.ExecuteSpecificCommand(_assetsContext.Inject(gameObject.AddComponent<UnitAttack>()));
            return;
        }
        
        var unitStop = commandExecutor as CommandExecutorBase<IStop>;
        if (unitStop != null)
        {
            unitStop.ExecuteSpecificCommand(_assetsContext.Inject(gameObject.AddComponent<UnitStop>()));
            return;
        }
        
        var unitPatrol = commandExecutor as CommandExecutorBase<IPatrol>;
        if (unitPatrol != null)
        {
            unitPatrol.ExecuteSpecificCommand(_assetsContext.Inject(gameObject.AddComponent<UnitPatrol>()));
            return;
        }
        
        var unitMove = commandExecutor as CommandExecutorBase<IMove>;
        if (unitMove != null)
        {
            unitMove.ExecuteSpecificCommand(_assetsContext.Inject(gameObject.AddComponent<UnitMove>()));
            return;
        }
        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
    }
}
