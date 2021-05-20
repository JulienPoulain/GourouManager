using UnityEngine;

[CreateAssetMenu(fileName = "Pourcentage", menuName = "GourouManager/Operation/Pourcentage")]
public class PercentageSO : OperationSO
{
    [SerializeField] private OperationSO m_operand;
    [SerializeField] private OperationSO m_percentage;

    public override void Initialize()
    {
        m_operand.Initialize();
        m_percentage.Initialize();
    }

    public override int Compute()
    {
        return (int) (m_operand.Compute() * ((float)m_percentage.Compute()/100));
    }

    public override string ToString()
    {
        return "( " + m_percentage + "% de " + m_operand + " )";
    }
}
