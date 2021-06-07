using UnityEngine;

public abstract class OperationSO : ScriptableObject, IInitializable
{
    [SerializeField] [TextArea(1,5)] private string m_overview;
    
    public abstract void Initialize();

    public abstract int Compute();

    #if UNITY_EDITOR
    private void OnValidate()
    {
        m_overview = ToString();
    }
    #endif
}
