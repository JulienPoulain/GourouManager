using UnityEngine;

public class SyncVar<T> : ScriptableObject, IInitializable
{
    [SerializeField] private string m_name;
    [SerializeField] public T m_initValue;
    [SerializeField] public T m_value;

    public string Name => m_name;
    
    public T Value
    {
        get => m_value;
        set => m_value = value;
    }

    public void Initialize()
    {
        m_value = m_initValue;
    }
}
