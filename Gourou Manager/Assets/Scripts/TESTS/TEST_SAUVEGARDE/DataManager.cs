using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private string m_saveFolderPath;

    public string SaveFolderPath => m_saveFolderPath;

    private static int s_currentID = 0;
    private void Start()
    {
        m_saveFolderPath = Application.streamingAssetsPath;
    }

    public static int GetNextID()
    {
        s_currentID++;
        return s_currentID;
    }
}
