using UnityEngine;

[CreateAssetMenu(fileName = "Multiplication", menuName = "GourouManager/Operation/Multiplication")]
public class MultiplicationSO : OperationSO
{
    [SerializeField] private OperationSO m_operation1;
    [SerializeField] private OperationSO m_operation2;
    
    public override int Compute()
    {
        return m_operation1.Compute() * m_operation2.Compute();
    }

    public override string ToString()
    {
        return "( " + m_operation1 + " * " + m_operation2 + " )";
    }
}
