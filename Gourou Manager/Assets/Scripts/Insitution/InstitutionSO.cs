using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution/Institution")]

public class InstitutionSO : ScriptableObject, IInitializable

{
    [SerializeField] public string m_name;
    [SerializeField] public string m_description;
    
    [Header("Variables")]
    
    [SerializeField] [Tooltip("Montant d’argent dont dispose l’Institution")] private RessourceSO m_funds;
    [SerializeField] [Tooltip("Citoyens composant l’Institution")] private RessourceSO m_members;
    [SerializeField] [Tooltip("Membres dévoués à l’Institution. 0 sauf pour religion, culte, BB.")] private RessourceSO m_fanatics;
    //[SerializeField] [Tooltip("Citoyens corrompus par l’Institution au prochain tour (+/-)")] private SyncIntSO m_impactOnPop;
    //[SerializeField] [Tooltip("Entier qui va venir alimenter la Crise à la fin de chaque tour")] public SyncIntSO m_impactOnCrise;
    [SerializeField] [Tooltip("Notoriété de l’Institution")] private RessourceSO m_publicExposure;
    [SerializeField] [Tooltip("Entier représentant le niveau de corruption de l’Institution")] private SyncIntSO m_corruption;
    [SerializeField] [Tooltip("Entier entre 0 et 100. 10 à l'initialisation")] private RessourceSO m_brutality;
    [SerializeField] private DecaySO m_decay;
    
    [Header("Objets liés à l'institution")]
    
    [SerializeField] [Tooltip("Personnages appartenant à l'institution")] public List<InterlocutorSO> m_interlocutorList;
    [SerializeField] [Tooltip("Exactions disponibles sans dialogue")] public List<ExactionSO> m_exactionList;
    [SerializeField] [Tooltip("Évènements se déclenchants selon certaines conditions sans intervention directe du joueur")] public List<TriggeredEventSO> m_triggeredEvents;
    [SerializeField] public OpinionOnTheCult m_option;

    /*public enum OpinionOnTheCult
    {
        Hostile,
        Suspicious,
        Indifferent,
        Complacent,
        Devoted
    }*/

    public RessourceSO Funds => m_funds;
    public RessourceSO Members => m_members;
    public RessourceSO Fanatics => m_fanatics;
    public RessourceSO PublicExposure => m_publicExposure;
    public RessourceSO Brutality => m_brutality;

    public DecaySO Decay => m_decay;

    public List<TriggeredEventSO> TriggeredEvents => m_triggeredEvents;

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
        
        /*if (m_impactOnPop == null)
        {
            Debug.Log("<color=red>ERROR :</color> Impact population manquant.");
        }
        else
        {
            m_impactOnPop.Initialize();
        }*/
        
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

        if (m_decay)
        {
            Debug.Log("<color=red>ERROR :</color> Niveau de corruption manquant.");
        }
        else
        {
            m_decay.Initialize();
        }
        
        foreach (InterlocutorSO interlocutor in m_interlocutorList)
        {
            interlocutor.Initialize();
        }
        
        foreach (ExactionSO exaction in m_exactionList)
        {
            exaction.Initialize();
        }
        
        foreach (TriggeredEventSO tEventSO in m_triggeredEvents)
        {
            tEventSO.Initialize();
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