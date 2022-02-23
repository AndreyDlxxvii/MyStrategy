using System;
using UnityEngine;

public class ScriptableValueBase <T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnSelected;
    
    public void SetValue(T value)
    {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }
}