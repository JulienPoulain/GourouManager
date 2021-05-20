using UnityEngine;

public abstract class ConditionSO : ScriptableObject, IInitializable
{
    public abstract void Initialize();
    
    public abstract bool IsOneValid();
}
