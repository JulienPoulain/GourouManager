using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRecord", menuName = "Gourou/Manager/record")]
public class RecordSO : ScriptableObject
{
    private Dictionary<IRecordable, int> m_idDictionary;
    private Dictionary<IRecordable, string> m_dataDictionary;

    public void Record(IRecordable p_so)
    {
        
    }
}
