using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Institutions", menuName = "Object/Institutions")]
public class InstitutionSo : ScriptableObject
{
    public ObjectType type;
    public string name;
    public int font;
    public int membres;
}
