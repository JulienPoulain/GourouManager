using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExactionSO", menuName = "Exactions")]

public class ExactionSO : ScriptableObject
{
    [SerializeField] private int duree;

    [SerializeField] private List<ImpactSO> impactList;
}
