using UnityEngine;

[CreateAssetMenu(fileName = "NewInfo", menuName = "GourouManager/Ressources/Info")]
public class InfoSO : SyncBoolSO
{
    [SerializeField] private string m_title;
    [SerializeField] private string m_description;
}
