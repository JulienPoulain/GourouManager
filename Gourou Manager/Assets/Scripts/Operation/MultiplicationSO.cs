using UnityEngine;

[CreateAssetMenu(fileName = "Multiplication", menuName = "GourouManager/Operation/Multiplication")]
public class MultiplicationSO : OperationSO
{
    [SerializeField] private OperationSO m_operation1;
    [SerializeField] private OperationSO m_operation2;

    public override void Initialize()
    {
        if (m_operation1 == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Opération 1 manquante.");
        }
        else
        {
            m_operation1.Initialize();
        }
        
        if (m_operation2 == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Opération 2 manquante.");
        }
        else
        {
            m_operation2.Initialize();
        }
    }

    public override int Compute()
    {
        return m_operation1.Compute() * m_operation2.Compute();
    }

    public override string ToString()
    {
        return "( " + m_operation1 + " * " + m_operation2 + " )";
    }
}
