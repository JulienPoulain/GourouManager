using UnityEngine;

[CreateAssetMenu(fileName = "OpInt", menuName = "GourouManager/Operation/Operande Int")]
public class OpIntSO : OperationSO
{
    [SerializeField] private int m_operand;
    
    public override void Initialize() {}

    public override int Compute()
    {
        return m_operand;
    }

    public override string ToString()
    {
        return name + " : " + m_operand;
    }
}
