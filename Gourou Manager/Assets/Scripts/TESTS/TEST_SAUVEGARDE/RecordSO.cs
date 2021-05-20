using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRecord", menuName = "Gourou/Manager/record")]
public class RecordSO : ScriptableObject
{
//    private Dictionary<int, int> m_idDictionary;
    private Dictionary<int, string[]> m_dataDictionary;

    public void Record(IRecordable p_so)
    {
        if (m_dataDictionary.ContainsKey(p_so.UUID)) return;
        
        string[] data;
        // test unicité
        p_so.recordSave(out data);
        m_dataDictionary.Add(p_so.UUID, data);
        
    }
}
