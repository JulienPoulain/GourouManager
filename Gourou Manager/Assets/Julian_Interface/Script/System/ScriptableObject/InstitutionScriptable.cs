using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInstitution", menuName = "Institution")]

public class InstitutionScriptable : ScriptableObject

{
    [SerializeField] public string m_name;
    [SerializeField] public SyncIntSO m_funds;
    [SerializeField] public SyncIntSO m_members;
    [SerializeField] public SyncIntSO m_fanatics;
    [SerializeField] public SyncIntSO m_publicExposure;
    [SerializeField] public SyncIntSO m_corruption;
    //impact ?


    public enum OpinionOnTheCult
    {
        Hostile,
        Suspicious,
        Indifferent,
        Complacent,
        Devoted
    }

    // public List<InterlocutorScriptable> InterlocutorList;

}