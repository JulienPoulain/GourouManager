using UnityEngine;

public abstract class ConditionSO<T> : ScriptableObject//, ICondition
{
    [SerializeField] protected T m_ressource;
    
    public abstract bool IsValid();
}
