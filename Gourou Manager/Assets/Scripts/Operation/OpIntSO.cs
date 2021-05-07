using UnityEngine;

[CreateAssetMenu(fileName = "OpInt", menuName = "GourouManager/Operation/Operand Int")]
public class OpIntSO : OperationSO
{
    [SerializeField] private int m_operand;
    public override int Compute()
    {
        return m_operand;
    }

    public override string ToString()
    {
        return name + " : " + m_operand;
    }
}
