using UnityEngine;

[CreateAssetMenu(fileName = "OpSyncInt", menuName = "GourouManager/Operation/Operande SyncInt")]
public class OpSyncIntSO : OperationSO
{
    [SerializeField] private SyncIntSO m_initOperand;
    private SyncIntSO m_operand;
    
    public override void Initialize()
    {
        m_operand = m_initOperand;
    }

    public override int Compute()
    {
        return m_operand.Value;
    }

    public override string ToString()
    {
        return m_operand.name + " : " + m_operand.Value.ToString();
    }
}
