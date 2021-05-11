using UnityEngine;

public class TestDialogueEvent : MonoBehaviour
{
    [SerializeField] private ConditionIntSO m_conditionInt;
    [SerializeField] private ConditionIntSO m_conditionInt2;
    [SerializeField] private ConditionBoolSO m_conditionBool;
    [SerializeField] private ConditionBoolSO m_conditionInfo;
    [SerializeField] private ApproachSO m_approach;
    [SerializeField] private ImpactSO m_impact;
    [SerializeField] private ImpactSO m_impact2;
    [SerializeField] private EventSO m_event;
    
    void Start()
    {
        // TEST CONDITION INT
        if (m_conditionInt == null)
        {
            Debug.Log("<color=red>ERROR :</color> Condition Int manquante.");
        }
        else
        {
            Debug.Log(m_conditionInt.ToString());
            if (m_conditionInt.IsOneValid())
                Debug.Log("Condition Int : OK");
            else
                Debug.Log("Condition Int : Pas OK");
        }
        
        // TEST CONDITION INT 2
        if (m_conditionInt2 == null)
        {
            Debug.Log("<color=red>ERROR :</color> Condition Int 2 manquante.");
        }
        else
        {
            if (m_conditionInt2.IsOneValid())
                Debug.Log("Condition Int 2 : OK");
            else
                Debug.Log("Condition Int 2 : Pas OK");
        }
        
        // TEST CONDITION BOOL
        if (m_conditionBool == null)
        {
            Debug.Log("<color=red>ERROR :</color> Condition Bool manquante.");
        }
        else
        {
            if (m_conditionBool.IsOneValid())
                Debug.Log("Condition Bool : OK");
            else
                Debug.Log("Condition Bool : Pas OK");
        }
        
        // TEST CONDITION INFO
        if (m_conditionInfo == null)
        {
            Debug.Log("<color=red>ERROR :</color> Condition Bool manquante.");
        }
        else
        {
            if (m_conditionInfo.IsOneValid())
                Debug.Log("Condition Info : OK (Info détenue)");
            else
                Debug.Log("Condition Info : Pas OK (Info non détenue)");
        }
        
        // TEST APPROCHE
        if (m_approach == null)
        {
            Debug.Log("<color=red>ERROR :</color> Approche manquante.");
        }
        else
        {
            // TEST ACCESSIBILITÉ APPROCHE
            /*if (m_approach.IsAccessible())
                Debug.Log("Approche accessible.");
            else
                Debug.Log("Approche inaccessible.");*/
            
            // TEST RÉUSSITE APPROCHE
            if (m_approach.IsSuccessful())
                Debug.Log("Approche réussit.");
            else
                Debug.Log("Approche échouée.");
        }
        
        // TEST ÉVÈVENEMENT
        if (m_impact == null)
        {
            Debug.Log("<color=red>ERROR :</color> Impact manquant.");
        }
        if (m_impact2 == null)
        {
            Debug.Log("<color=red>ERROR :</color> Impact 2 manquant.");
        }
        if (m_event == null)
        {
            Debug.Log("<color=red>ERROR :</color> Event manquant.");
        }
        else
        {
            Event event1 = new Event(m_event);
            while (m_event.Duration > 0)
            {
                Debug.Log($"Application de l'évènement ({event1.Duration}).");
                event1.AdvanceTime(1);
            }
        }
    }
}
