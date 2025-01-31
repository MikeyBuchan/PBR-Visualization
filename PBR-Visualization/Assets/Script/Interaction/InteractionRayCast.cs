﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRayCast : MonoBehaviour
{
    public float range;
    RaycastHit hit;

    void Update()
    {
        RayCastFunction();
    }

    void RayCastFunction()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Interaction")
            {
                GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(true);
                if (Input.GetButtonDown("Interaction"))
                {
                    hit.transform.GetComponent<InteractionBase>().Interact();
                }
            }
        }
        else
        {
            GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(false);
        }
    }
}
