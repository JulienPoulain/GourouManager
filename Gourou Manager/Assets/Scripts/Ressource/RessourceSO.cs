using UnityEngine;

[CreateAssetMenu(fileName = "NewRessource", menuName = "GourouManager/Ressource/Ressource")]
public class RessourceSO : SyncIntSO
{
    public override int Value
    {
        get => m_value;
        set
        {
            if (m_value < 0)
                m_value = 0;
            else
                m_value = value;
        }
    }
}
