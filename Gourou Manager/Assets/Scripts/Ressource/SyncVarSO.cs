using UnityEngine;
using System;
using UnityEngine.UIElements;

public class SyncVar<T> : ScriptableObject, IInitializable
{
    [SerializeField] private string m_name;
    [SerializeField] protected T m_initValue;
    [SerializeField] protected T m_value;

    public string Name => m_name;
    
    
    public event Action<T> onValueChanged; 
    
    public virtual T Value
    {
        get => m_value;
        set
        {
            // eventuelement seulement si changement
            m_value = value;
            WarnValueChanged();
        }
    }

    protected void WarnValueChanged()
    {
        if (onValueChanged != null) onValueChanged(m_value);
    }

    public void Initialize()
    {
        Value = m_initValue;
    }
}
