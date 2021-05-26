using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDecay", menuName = "GourouManager/Ressource/Corruption")]
public class DecaySO : SyncIntSO
{
    public int Value
    {
        set
        {
            if (m_value < 0)
                m_value = 0;
            else if (m_value > 100)
                m_value = 100;
        }
    }
}
