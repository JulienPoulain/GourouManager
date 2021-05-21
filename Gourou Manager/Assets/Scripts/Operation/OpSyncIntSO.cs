using UnityEngine;

[CreateAssetMenu(fileName = "OpSyncInt", menuName = "GourouManager/Operation/Operande SyncInt")]
public class OpSyncIntSO : OperationSO
{
    [SerializeField] private SyncIntSO m_operand;
    
    public override void Initialize() {}

    public override int Compute()
    {
        return m_operand.Value;
    }

    public override string ToString()
    {
        return m_operand.name + " : " + m_operand.Value.ToString();
    }
}
