using System;
using DecayLvlMethods;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDecay", menuName = "GourouManager/Ressource/Corruption")]
public class DecaySO : SyncIntSO
{
    public override int Value
    {
        get => m_value;
        set => m_value = Mathf.Clamp(value, 0, 100);
    }

    public DecayLvl GetDecayLvl()
    {
        foreach (DecayLvl iDecayLvl in Enum.GetValues(typeof(DecayLvl)))
            if (iDecayLvl.lvlMin() <= Value && Value <= iDecayLvl.lvlMax())
                return iDecayLvl;
        return DecayLvl.None;
    }
}
