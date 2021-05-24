using UnityEngine;

public class TestTriggeredEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Tour : {GameManager.Instance.Turn}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.EndTurn();
            Debug.Log($"Tour : {GameManager.Instance.Turn}");
            Debug.Log($"Exactions  : {EventRegister.Instance.GetExactions(GameManager.Instance.Turn-1).Count}");
            Debug.Log($"Évènements : {EventRegister.Instance.GetEvents(GameManager.Instance.Turn-1).Count}");
        }
    }
}
