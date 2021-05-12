using UnityEngine;

public class SyncVar<T> : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] public T m_value;

    public string Name => m_name;
    
    public T Value
    {
        get => m_value;
        set => m_value = value;
    }
}
