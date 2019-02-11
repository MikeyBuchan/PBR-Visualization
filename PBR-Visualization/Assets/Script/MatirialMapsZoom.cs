using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    MatirialMapsZoomBase baseClass;
    public float speed;
    [TextArea]
    public string nameObj, infoObj, extraInfoObj;

    public Material normalMaterial,hightLightMaterial;

    void Start()
    {
        baseClass = gameObject.transform.parent.gameObject.GetComponent<MatirialMapsZoomBase>();
    }

    void Update()
    {
        if (baseClass.mayZoom == false)
        {
            RotateObject();
        }
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
                baseClass.SeroundPress(nameObj, infoObj, extraInfoObj, transform);
                GetComponent<Renderer>().material = normalMaterial;
            }
        }
    }

    void RotateObject()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.Rotate(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0 * Time.deltaTime * speed, Space.World);
        }
    }
}
