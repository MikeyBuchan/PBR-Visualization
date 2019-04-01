﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialMapsZoom : MonoBehaviour
{
    MaterialMapsZoomBase baseClass;
    public float speed;
    [TextArea]
    public string nameObj, infoObj, extraInfoObj;

    public Material normalMaterial,hightLightMaterial;
    public int myNumber;

    public GameObject nameUI;

    public float lerpSpeed;
    Quaternion startRotation;
    
    void Start()
    {
        baseClass = transform.parent.parent.GetComponent<MaterialMapsZoomBase>();
        startRotation = gameObject.transform.rotation;
        normalMaterial = GetComponent<Renderer>().material;
        nameUI.SetActive(false);  
    }

    void Update()
    {
        if (baseClass != null && baseClass.zoomdIn == true)
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
            nameUI.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material = normalMaterial;
        nameUI.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove == false)
        {
            if (baseClass.zoomdIn == false && GameObject.FindWithTag("UiManager").GetComponent<UIManager>().advancedBool == false && GameObject.FindWithTag("UiManager").GetComponent<UIManager>().extrab == false)//moet nog iets achter
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    baseClass.SeroundPress(myNumber);
                    GetComponent<Renderer>().material = normalMaterial;
                    baseClass.myChildNumber = myNumber;
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