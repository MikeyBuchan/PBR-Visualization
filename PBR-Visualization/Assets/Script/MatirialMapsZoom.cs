using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    MatirialMapsZoomBase baseClass;
    public string nameObj;
    public string infoObj;
    public Material normalMaterial,hightLightMaterial;

    void Start()
    {
        baseClass = gameObject.transform.parent.gameObject.GetComponent<MatirialMapsZoomBase>();
    }

    public void OnMouseEnter()
    {
        if(baseClass.allowRotation)
            GetComponent<Renderer>().material = hightLightMaterial;
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material = normalMaterial;
    }

    void OnMouseDown()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                baseClass.SeroundPress(nameObj, infoObj, transform);
                GetComponent<Renderer>().material = normalMaterial;
            }
        }
    }
}
