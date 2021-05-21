using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution/Institution")]

public class InstitutionSO : ScriptableObject, IInitializable

{
    [SerializeField] public string m_name;
    [SerializeField] public string m_description;
    
    [Header("Variables")]
    
    [SerializeField] [Tooltip("Montant d’argent dont dispose l’Institution")] public SyncIntSO m_funds;
    [SerializeField] [Tooltip("Citoyens composant l’Institution")] public SyncIntSO m_members;
    [SerializeField] [Tooltip("Membres dévoués à l’Institution. 0 sauf pour religion, culte, BB.")] public SyncIntSO m_fanatics;
    [SerializeField] [Tooltip("Citoyens corrompus par l’Institution au prochain tour (+/-)")] public SyncIntSO m_impactOnPop;
    //[SerializeField] [Tooltip("Entier qui va venir alimenter la Crise à la fin de chaque tour")] public SyncIntSO m_impactOnCrise;
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

    public void Initialize()
    {
        if (m_funds == null)
        {
            Debug.Log("<color=red>ERROR :</color> Fonds manquants.");
        }
        else
        {
            m_funds.Initialize();
        }
        if (m_members == null)
        {
            Debug.Log("<color=red>ERROR :</color> Membres manquants.");
        }
        else
        {
            m_members.Initialize();
        }
        if (m_fanatics == null)
        {
            Debug.Log("<color=red>ERROR :</color> Fanatiques manquants.");
        }
        else
        {
            m_fanatics.Initialize();
        }
        if (m_impactOnPop == null)
        {
            Debug.Log("<color=red>ERROR :</color> Impact population manquant.");
        }
        else
        {
            m_impactOnPop.Initialize();
        }
        if (m_publicExposure == null)
        {
            Debug.Log("<color=red>ERROR :</color> Exposition publique manquante.");
        }
        else
        {
            m_publicExposure.Initialize();
        }
        if (m_corruption == null)
        {
            Debug.Log("<color=red>ERROR :</color> Corruption manquante.");
        }
        else
        {
            m_corruption.Initialize();
        }
        if (m_brutality == null)
        {
            Debug.Log("<color=red>ERROR :</color> Brutalité manquante.");
        }
        else
        {
            m_brutality.Initialize();
        }
        foreach (InterlocutorSO interlocutor in m_interlocutorList)
        {
            interlocutor.Initialize();
        }
        foreach (ExactionSO exaction in m_exactionList)
        {
            exaction.Initialize();
        }
        foreach (ExactionSO tExaction in m_triggeredExactions)
        {
            tExaction.Initialize();
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