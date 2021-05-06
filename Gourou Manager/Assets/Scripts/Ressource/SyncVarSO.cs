using UnityEngine;

public class SyncVar<T> : ScriptableObject
{
    [SerializeField] public T m_value;

    public T Value
    {
        get
        {
            return m_value;
        }
        
        set
        {
            if (m_value.Equals(value)) return;
            m_value = value;
        }
    }
}
