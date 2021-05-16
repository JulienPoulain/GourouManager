using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution/Institution")]

public class InstitutionSO : ScriptableObject

{
    [SerializeField] public string m_name;
    
    [Header("Variables")]
    
    [SerializeField] [Tooltip("Montant d’argent dont dispose l’Institution")] public SyncIntSO m_funds;
    [SerializeField] [Tooltip("Citoyens composant l’Institution")] public SyncIntSO m_members;
    [SerializeField] [Tooltip("Membres dévoués à l’Institution. 0 sauf pour religion, culte, BB.")] public SyncIntSO m_fanatics;
    [SerializeField] [Tooltip("Citoyens corrompus par l’Institution au prochain tour (+/-)")] public SyncIntSO m_impactOnPop;
    [SerializeField] [Tooltip("Entier qui va venir alimenter la Crise à la fin de chaque tour")] public SyncIntSO m_impactOnCrise;
    [SerializeField] [Tooltip("Notoriété de l’Institution")] public SyncIntSO m_publicExposure;
    [SerializeField] [Tooltip("Entier représentant le niveau de corruption de l’Institution")] public SyncIntSO m_corruption;
    [SerializeField] [Tooltip("Entier entre 0 et 100. 10 à l'initialisation")] public SyncIntSO m_brutality;
    
    [Header("Objets liés à l'institution")]
    
    [SerializeField] [Tooltip("Personnages appartenant à l'institution")] public List<InterlocutorSO> m_interlocutorList;
    [SerializeField] [Tooltip("Exactions disponibles sans dialogue")] public List<ExactionSO> m_exactionList;
    [SerializeField] [Tooltip("Exactions se déclenchants selon certaines conditions sans intervention directe du joueur")] public List<ExactionSO> m_triggeredExactions;
    [SerializeField] public OpinionOnTheCult m_option;
    
    public List<ExactionSO> m_remainingTriggeredExactions = new List<ExactionSO>();

    public enum OpinionOnTheCult
    {
        Hostile,
        Suspicious,
        Indifferent,
        Complacent,
        Devoted
    }
    
    public List<ExactionSO> RemainingTriggeredExactions => m_remainingTriggeredExactions;

    public void init()
    {
        foreach (ExactionSO exaction in m_triggeredExactions)
        {
            m_remainingTriggeredExactions.Add(exaction);
        }
    }

    public List<ApproachSO> PossibleDialogues()
    {
        List<ApproachSO> dialoguesList = new List<ApproachSO>();

        foreach (InterlocutorSO interlocutor in m_interlocutorList)
        {
            if (interlocutor.IsAccessible())
                dialoguesList.AddRange(interlocutor.m_approach);
        }
        
        return dialoguesList;
    }
    

}