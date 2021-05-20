using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSauvegarde : MonoBehaviour
{
    [SerializeField] private DataSO m_data1;
    [SerializeField] private DataSO m_data2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (m_data1 == null)
        {
            Debug.Log("<color=red>ERROR :</color> Data 1 manquante.");
        }
        if (m_data2 == null)
        {
            Debug.Log("<color=red>ERROR :</color> Data 2 manquante.");
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("On sauvegarde !");
            
            if (m_data1 == null)
            {
                Debug.Log("<color=red>ERROR :</color> Data 1 manquante bordel !");
            }
            else
            {
                m_data1.save();
            }
            
            if (m_data2 == null)
            {
                Debug.Log("<color=red>ERROR :</color> Data 2 manquante bordel !");
            }
            else
            {
                m_data2.save();
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (m_data1 == null)
            {
                Debug.Log("<color=red>ERROR :</color> Data 1 manquante bordel !");
            }
            else
            {
                m_data1.load();
            }
            
            if (m_data2 == null)
            {
                Debug.Log("<color=red>ERROR :</color> Data 2 manquante bordel !");
            }
            else
            {
                m_data2.load();
            }
        }
    }*/
}
