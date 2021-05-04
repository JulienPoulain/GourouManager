using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewCrise", menuName = "GourouManager/Crises/CriseStruct")]
public class StructEventCrisesSO : ScriptableObject
{
    [FormerlySerializedAs("m_crises")] public CrisesSO m_tauxDeCrise;
    
    [SerializeField]
    [Tooltip("Nombre de paliers souhaités dans la crise")]
    private int[] m_paliers;

    [FormerlySerializedAs("nombreDePalier")]
    [SerializeField] 
    [Tooltip("Nombre de paliers ajoutés -1")]
    private List<PaliersSO> m_nombreDePalier = new List<PaliersSO>();

    void Start()
    { 
        Fonction();
        PaliersSO palierActif = Fonction();

        palierActif.m_active = true;
        Debug.Log(Fonction());

    }
    
    //Fonction qui cherche le palier correspondant au taux de crise et le return
    PaliersSO Fonction ()
    {
        for (int i = 0; i<m_paliers.Length; i++)
        {
            if (m_tauxDeCrise.m_tauxDeCrise >= m_paliers[i] && m_tauxDeCrise.m_tauxDeCrise < m_paliers[i + 1])
            {
                //Debug.Log(nombreDePalier[i]);
                return m_nombreDePalier[i];
            }
        }
        return null;
    }


}




