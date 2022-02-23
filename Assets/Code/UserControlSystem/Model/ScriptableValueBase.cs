using System;
using UnityEngine;

public class ScriptableValueBase <T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
    {
        private readonly ScriptableValueBase<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;
        
        public bool IsCompleted => _isCompleted;
        public TAwaited GetResult() => _result;

        public NewValueNotifier(ScriptableValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnSelected += OnSelected;
        }

        private void OnSelected(TAwaited obj)
        {
            _scriptableObjectValueBase.OnSelected -= OnSelected;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
    }

    public T CurrentValue { get; private set; }
    public Action<T> OnSelected;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }

}
