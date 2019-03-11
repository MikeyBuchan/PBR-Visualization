using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportationScript : MonoBehaviour
{
    public GameObject popUp;

    private void Start()
    {
        popUp.SetActive(false);
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            Debug.Log("col");
            popUp.SetActive(true);
            
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            Debug.Log("col II");
            popUp.SetActive(false);
            
        }
    }

    void YesSwitch()
    {
        Debug.Log("YES PLZ");
    }

    void NoSwitch()
    {
        Debug.Log("NO PLZ");
        popUp.SetActive(false);
    }
}
