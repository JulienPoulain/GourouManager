using UnityEngine;

[CreateAssetMenu(fileName = "Addition", menuName = "GourouManager/Operation/Addition")]
public class AdditionSO : OperationSO
{
    [SerializeField] private OperationSO m_operation1;
    [SerializeField] private OperationSO m_operation2;

    public override void Initialize()
    {
        m_operation1.Initialize();
        m_operation2.Initialize();
    }

    public override int Compute()
    {
        return m_operation1.Compute() + m_operation2.Compute();
    }

    public override string ToString()
    {
        return "( " + m_operation1 + " + " + m_operation2 + " )";
    }
}
