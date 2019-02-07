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
        Debug.DrawRay(transform.position, transform.forward * range, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Interaction")
            {
                GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(true);
                if (Input.GetButtonDown("Interaction"))
                {
                    gameObject.GetComponent<PlayerLook>().freeMove = false;
                    //gameObject.transform.position = GameObject.FindWithTag("Interaction").GetComponentInChildren<MatirialMapsZoom>().cameraBasePos += new Vector3(1,0,0);
                }
            }

        }
        else
        {
            GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(false);
        }
    }
}
