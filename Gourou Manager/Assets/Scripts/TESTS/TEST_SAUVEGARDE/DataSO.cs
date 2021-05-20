using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "newData", menuName = "GourouManager/TEST/DataSO")]
public class DataSO : ScriptableObject/*, IRecordable*/
{

 //   [SerializeField] private int m_uuid = -1;
    public int UUID { get; private set; }

    [SerializeField] private int m_valInt;
    [SerializeField]private int m_runtimeValInt;
    
    [SerializeField] private float m_valFloat;
    [SerializeField]private float m_runtimeValfloat;

    [SerializeField] private string m_valString;
    [SerializeField] private string m_runtimeValString;

    [SerializeField] private List<DataSO> m_valData;


    private void OnEnable()
    {
        m_runtimeValInt = m_valInt;
    }


    //  private string jsonString;

   /* private void Awake()
    {
        #if UNITY_EDITOR
        if (m_uuid == -1)
        {
            UUID = DataManager.GetNextID();
            EditorUtility.SetDirty(this);
        }
        #endif // UNITY_EDITOR
    }*/

/*
    public void save()
    {
        jsonString = JsonUtility.ToJson(this);
        Debug.Log(jsonString);
        File.WriteAllText(Path.Combine(DataManager.Instance.SaveFolderPath, "save.json"), jsonString);
    }

    public void load()
    {
        jsonString = File.ReadAllText(Path.Combine(DataManager.Instance.SaveFolderPath, "save.json"));
        //this = JsonUtility.FromJson<DataSO>(jsonString);
    }

    public void recordSave(out string[] o_data)
    {
        o_data = new string[]
        {
            m_valInt.ToString(),
            m_valFloat.ToString(),
            m_valString
        };

        if (m_valData == null) return;
        
        
            foreach (DataSO child in m_valData)
            {
                //RecordSO.Save(child);
            }
        


    }
*/


}
