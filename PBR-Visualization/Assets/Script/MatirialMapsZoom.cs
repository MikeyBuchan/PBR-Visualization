using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    MatirialMapsZoomBase baseClass;
    public string nameObj;
    public string infoObj;

    void Start()
    {
        baseClass = gameObject.transform.parent.gameObject.GetComponent<MatirialMapsZoomBase>();
    }

    // geef index mee welke jij bent en welke
    void OnMouseDown()
    {
        if (GameObject.FindWithTag("Player").GetComponentInChildren<PlayerLook>().freeMove == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                baseClass.SeroundPress(nameObj, infoObj, transform);
            }
        }
    }
}
