using System;
using UnityEngine;

public class ScriptableValueBase <T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly ScriptableValueBase<TAwaited> _scriptableObjectValueBase;

        public NewValueNotifier(ScriptableValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnSelected += onNewValue;
        }

        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnSelected -= onNewValue;
            OnWaitFinish(obj);
        }

    }

    public T CurrentValue { get; private set; }
    public Action<T> OnSelected;

    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnSetValue(value);
        OnSelected?.Invoke(value);
    }
    
    protected virtual void OnSetValue(T value)
    {

    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}
