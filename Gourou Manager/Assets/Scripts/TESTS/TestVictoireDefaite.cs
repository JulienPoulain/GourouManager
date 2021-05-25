using UnityEngine;

public class TestVictoireDefaite : MonoBehaviour
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
        }
    }
}
