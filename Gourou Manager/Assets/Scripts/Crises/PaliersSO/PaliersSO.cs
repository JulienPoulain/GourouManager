using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPalier", menuName = "GourouManager/Crises/Palier")]
public class PaliersSO : ScriptableObject
{
    [SerializeField] private List<EventSO> nbreEvenements;

    [SerializeField] public bool m_active;
    

}
