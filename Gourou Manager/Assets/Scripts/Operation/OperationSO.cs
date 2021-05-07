using UnityEngine;

public abstract class OperationSO : ScriptableObject
{
    [SerializeField] [TextArea(1,5)] private string m_overview;

    public abstract int Compute();

    private void OnValidate()
    {
        m_overview = ToString();
    }
}
