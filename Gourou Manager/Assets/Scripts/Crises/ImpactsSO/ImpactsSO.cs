using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImpactSO", menuName = "Impacts")]
public class ImpactsSO : ScriptableObject
{
 [SerializeField] private int amplitude;
 [SerializeField] private List<SyncIntSO> syncList;

}
