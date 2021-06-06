using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionSO : ScriptableObject, IInitializable
{
    public static bool IsAllValid(List<ConditionSO> p_conditions)
    {
        foreach (ConditionSO condition in p_conditions)
        {
            if (!condition.IsValid())
                return false;
        }
        return true;
    }
    
    public abstract void Initialize();

    public abstract string Express();
    
    public abstract bool IsValid();
}
