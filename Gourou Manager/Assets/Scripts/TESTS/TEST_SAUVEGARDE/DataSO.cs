using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "newData", menuName = "GourouManager/TEST/DataSO")]
public class DataSO : ScriptableObject, IRecordable
{
    [SerializeField] private int m_valInt;
    [SerializeField] private float m_valFloat;
    [SerializeField] private string m_valString;
    [SerializeField] private List<DataSO> m_valData;

    private string jsonString;

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

    public void recordSave()
    {
        string[] content = new string[]
        {
            m_valInt.ToString(),
            m_valFloat.ToString(),
            m_valString
        };
    }
}
