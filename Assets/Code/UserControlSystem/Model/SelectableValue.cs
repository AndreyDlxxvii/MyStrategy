using System;
using UniRx;
using UnityEngine;
[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : StatefulScriptableObjectValueBase<ISelectable>
{
    public ReactiveProperty<ISelectable> OnSelectSubscribe;

    protected override void OnSetValue(ISelectable value)
    {
        OnSelectSubscribe.Value = value;
    }
}