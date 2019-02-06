using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float range;
    RaycastHit hit;

    void Update()
    {
        InteractionFunction();
    }

    void InteractionFunction()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Interaction")
            {
                if (Input.GetButtonDown("Interaction"))
                {
                    GameObject.FindWithTag("Uimanager").GetComponent<UIManager>().interactDisplay.SetActive(true);
                    gameObject.GetComponent<PlayerLook>().free = false;
                    //gameObject.transform.position = 
                }
            }
        }
    }
}
