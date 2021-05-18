using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private string m_saveFilePath;

    public string SaveFilePath => m_saveFilePath;

    private void Start()
    {
        m_saveFilePath = Application.streamingAssetsPath;
    }
}
