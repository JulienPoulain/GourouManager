using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private string m_saveFolderPath;

    public string SaveFolderPath => m_saveFolderPath;

    private void Start()
    {
        m_saveFolderPath = Application.streamingAssetsPath;
    }
}
