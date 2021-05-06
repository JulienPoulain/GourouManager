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
    [SerializeField] public SyncIntSO m_publicExposure;
    [SerializeField] public SyncIntSO m_corruption;
    [SerializeField] public List<InterlocutorSO> InterlocutorList;

    [SerializeField] public OpinionOnTheCult m_opition;
    //impact ?

    public List<DialogueSO> PossibleDialogues()
    {
        List<DialogueSO> DialoguesList = new List<DialogueSO>();

        foreach (InterlocutorSO interlocutor in InterlocutorList)
        {
            if (interlocutor.IsAccessible())
                DialoguesList.Add(interlocutor.m_dialogue);
        }
        
        return DialoguesList;
    }
    

}