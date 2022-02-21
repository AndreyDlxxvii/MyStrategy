using System;
using UnityEngine;

public class ScriptableBase<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnValue?.Invoke(value);
    }
}