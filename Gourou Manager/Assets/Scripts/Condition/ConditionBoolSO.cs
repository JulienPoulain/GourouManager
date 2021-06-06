using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "NewConditionBool", menuName = "GourouManager/Condition/ConditionBool")]
public class ConditionBoolSO : ConditionSO
{
    [SerializeField] private SyncBoolSO m_syncBool;
    
    public override void Initialize()
    {
        if (m_syncBool == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} SyncBool manquant.");
        }
        else
        {
            m_syncBool.Initialize();
        }
    }

    public override string Express()
    {
        return "Vous devez posséder l'info : " + m_syncBool.Name + ".";
    }

    public override bool IsValid()
    {
        return m_syncBool.Value;
    }
}
