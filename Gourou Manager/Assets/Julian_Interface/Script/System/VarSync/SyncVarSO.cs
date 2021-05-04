using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncVar<T> : ScriptableObject// where T : IComparable<T>
{
    [SerializeField] public T m_value;

    public T Value
    {
        get => m_value;
        set => m_value = value;
    }

    /*public int CompareTo(SynchVar<T> p_other)
    {
        if (p_other == null) return 1;

        return m_value.CompareTo(p_other.m_value);
    }

    public static bool operator > (SynchVar<T> operand1, SynchVar<T> operand2)
    {
        return operand1.CompareTo(operand2) > 0;
    }

    public static bool operator < (SynchVar<T> operand1, SynchVar<T> operand2)
    {
        return operand1.CompareTo(operand2) < 0;
    }
    
    public static bool operator >= (SynchVar<T> operand1, SynchVar<T> operand2)
    {
        return operand1.CompareTo(operand2) >= 0;
    }

    public static bool operator <= (SynchVar<T> operand1, SynchVar<T> operand2)
    {
        return operand1.CompareTo(operand2) <= 0;
    }*/
}
