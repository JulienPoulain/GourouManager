using UnityEngine;

public class TestCalculImpact : MonoBehaviour
{
    [SerializeField] private OperationSO m_operation;

    void Start()
    {
        // TEST D'UNE OPÉRATION
        if (m_operation == null)
        {
            Debug.Log("<color=red>ERROR :</color> Operation manquante.");
        }
        else
        {
            Debug.Log($"Test de l'opération : {m_operation} = {m_operation.Compute()} $");
        }
    }
}
