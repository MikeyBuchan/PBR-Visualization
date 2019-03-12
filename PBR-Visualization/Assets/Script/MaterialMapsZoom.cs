using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMapsZoom : MonoBehaviour
{
    MaterialMapsZoomBase baseClass;
    public float speed;
    [TextArea]
    public string nameObj, infoObj, extraInfoObj;

    public Material normalMaterial,hightLightMaterial;
    public int myNumber;

    public float lerpSpeed;
    Quaternion startRotation;
    

    void Start()
    {
        baseClass = gameObject.transform.parent.gameObject.GetComponent<MaterialMapsZoomBase>();
        startRotation = gameObject.transform.rotation;
        normalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (baseClass.zoomdIn == true)
        {
            RotateObject();
        }
        else if(gameObject.transform.rotation != startRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * lerpSpeed);
        }
    }

    public void OnMouseEnter()
    {
        if (baseClass.allowRotation == true)
        {
            GetComponent<Renderer>().material = hightLightMaterial;
        }
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material = normalMaterial;
    }

    void OnMouseDown()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove == false)
        {
            if (baseClass.zoomdIn == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    baseClass.SeroundPress(myNumber);
                    GetComponent<Renderer>().material = normalMaterial;
                    baseClass.myChildNumber = myNumber;
                    baseClass.zoomdIn = true;
                }
            }
        }
    }

    void RotateObject()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed, Space.World);
        }
    }
}
