using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crisis", menuName = "Object/Crisis")]
public class Crisis : ScriptableObject
{
    public ObjectType type;
    public string name;
    public int TauxDeCrise;
}
