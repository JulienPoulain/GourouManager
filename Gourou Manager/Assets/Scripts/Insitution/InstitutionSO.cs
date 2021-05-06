using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution")]

public class InstitutionSO : ScriptableObject

{
    [SerializeField] public string m_name;
    [Header("Variables")]
    [SerializeField] [Tooltip("montant d’argent dont dispose l’Institution")] public SyncIntSO m_funds;
    [SerializeField] [Tooltip("citoyens composant l’Institution")] public SyncIntSO m_members;
    [SerializeField] [Tooltip("membres dévoués à l’Institution. 0 sauf pour religion, culte, BB.")] public SyncIntSO m_fanatics;
    [SerializeField] [Tooltip("citoyens corrompus par l’Institution au prochain tour (+/-)")] public SyncIntSO m_impactOnPop;
    [SerializeField] [Tooltip("entier qui va venir alimenter la Crise à la fin de chaque tour")] public SyncIntSO m_impactOnCrise;
    [SerializeField] [Tooltip("notoriété de l’Institution")] public SyncIntSO m_publicExposure;
    [SerializeField] [Tooltip("entier représentant le niveau de corruption de l’Institution")] public SyncIntSO m_corruption;
    [SerializeField] [Tooltip("entier entre 0 et 100. 10 à l'initialisation")] public SyncIntSO m_brutality;
    [Header("Objets liés à l'institution")]
    [SerializeField] [Tooltip("personnage appartenant à l'institution")] public List<InterlocutorSO> m_interlocutorList;
    [SerializeField] [Tooltip("exactions disponibles sans dialogue")] public List<ExactionSO> m_exactionList;
    [SerializeField] [Tooltip("en rapport avec l’Institution, déclenchés sous certaines conditions")] public List<EventSO> m_eventList;

    enum OpinionOnTheCult
    {
        Hostile,
        Suspicious,
        Indifferent,
        Complacent,
        Devoted
    }

    public List<ApproachSO> PossibleDialogues()
    {
        List<ApproachSO> DialoguesList = new List<ApproachSO>();

        foreach (InterlocutorSO interlocutor in m_interlocutorList)
        {
            if (interlocutor.IsAccessible())
                DialoguesList.AddRange(interlocutor.m_approach);
        }
        
        return DialoguesList;
    }
    

}