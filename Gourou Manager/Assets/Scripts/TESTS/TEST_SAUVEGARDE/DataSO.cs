using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "newData", menuName = "GourouManager/TEST/DataSO")]
public class DataSO : ScriptableObject
{
    [SerializeField] private int m_valInt;
    [SerializeField] private float m_valFloat;
    [SerializeField] private string valFloat;

    private string jsonString;

    public void save()
    {
        File.WriteAllText(DataManager.Instance.SaveFilePath, JsonUtility.ToJson(this));
    }
}
