using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution")]

public class InstitutionSO : ScriptableObject

{
    [SerializeField] public string m_name;
    
    [SerializeField] public SyncIntSO m_funds;
    [SerializeField] public SyncIntSO m_members;
    [SerializeField] public SyncIntSO m_fanatics;
    [SerializeField] public SyncIntSO m_impactOnPop;
    [SerializeField] public SyncIntSO m_impactOnCrise;
    [SerializeField] public SyncIntSO m_publicExposure;
    [SerializeField] public SyncIntSO m_corruption;
    [SerializeField] public List<InterlocutorSO> m_interlocutorList;
    [SerializeField] public List<ExactionSO> m_exactionList;
    [SerializeField] public List<EventSO> m_eventList;
    //impact ?
    
    enum OpinionOnTheCult
    {
        Hostile,
        Suspicious,
        Indifferent,
        Complacent,
        Devoted
    }

    public List<DialogueSO> PossibleDialogues()
    {
        List<DialogueSO> DialoguesList = new List<DialogueSO>();

        foreach (InterlocutorSO interlocutor in m_interlocutorList)
        {
            if (interlocutor.IsAccessible())
                DialoguesList.Add(interlocutor.m_dialogue);
        }
        
        return DialoguesList;
    }
    

}