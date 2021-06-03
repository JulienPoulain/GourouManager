using System;
using DecayLvlMethods;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDecay", menuName = "GourouManager/Attribut/Corruption")]
public class DecaySO : SyncIntSO
{
    public override int Value
    {
        get => m_value;
        set
        {
            m_value = Mathf.Clamp(value, 0, 100);
            WarnValueChanged();
        } 
    }

    public DecayLvl GetDecayLvl()
    {
        foreach (DecayLvl iDecayLvl in Enum.GetValues(typeof(DecayLvl)))
            if (iDecayLvl.LvlMin() <= Value && Value <= iDecayLvl.LvlMax())
                return iDecayLvl;
        return DecayLvl.None;
    }
}
