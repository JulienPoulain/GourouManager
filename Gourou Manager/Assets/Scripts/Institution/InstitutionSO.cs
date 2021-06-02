using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "GourouManager/Institution/Institution")]

public class InstitutionSO : ScriptableObject, IInitializable

{
    [SerializeField] public string m_name;
    [SerializeField] public string m_description;
    
    [Header("Variables")]
    
    [SerializeField] [Tooltip("Montant d’argent dont dispose l’Institution")] private RessourceSO m_funds;
    [SerializeField] [Tooltip("Citoyens composant l’Institution")] private RessourceSO m_members;
    [SerializeField] [Tooltip("Membres dévoués à l’Institution. 0 sauf pour religion, culte, BB.")] private RessourceSO m_fanatics;
    [SerializeField] [Tooltip("Notoriété de l’Institution")] private RessourceSO m_publicExposure;
    [SerializeField] [Tooltip("Entier entre 0 et 100. 10 à l'initialisation")] private RessourceSO m_brutality;
    [SerializeField] [Tooltip("Entier représentant le niveau de corruption de l’Institution")] private DecaySO m_decay;
    
    [Header("Objets liés à l'institution")]
    
    [SerializeField] [Tooltip("Personnages appartenant à l'institution")] public List<InterlocutorSO> m_interlocutorList;
    [SerializeField] [Tooltip("Exactions disponibles sans dialogue")] public List<ExactionSO> m_exactionList;
    [SerializeField] [Tooltip("Évènements se déclenchants selon certaines conditions sans intervention directe du joueur")] public List<TriggeredEventSO> m_triggeredEvents;

    [SerializeField] private Sprite m_pictogram;

    public RessourceSO Funds => m_funds;
    public RessourceSO Members => m_members;
    public RessourceSO Fanatics => m_fanatics;
    public RessourceSO PublicExposure => m_publicExposure;
    public RessourceSO Brutality => m_brutality;

    public DecaySO Decay => m_decay;

    public List<TriggeredEventSO> TriggeredEvents => m_triggeredEvents;

    public Sprite Pictogram => m_pictogram;

    public void Initialize()
    {
        if (m_funds == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Fonds manquants.");
        }
        else
        {
            m_funds.Initialize();
        }
        
        if (m_members == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Membres manquants.");
        }
        else
        {
            m_members.Initialize();
        }
        
        if (m_fanatics == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Fanatiques manquants.");
        }
        else
        {
            m_fanatics.Initialize();
        }
        
        if (m_publicExposure == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Exposition publique manquante.");
        }
        else
        {
            m_publicExposure.Initialize();
        }

        if (m_brutality == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Brutalité manquante.");
        }
        else
        {
            m_brutality.Initialize();
        }

        if (m_decay == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Niveau de corruption manquant.");
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