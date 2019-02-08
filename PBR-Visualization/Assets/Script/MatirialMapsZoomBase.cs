﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoomBase : MonoBehaviour
{
    [Header("Camera")]
    public Vector3 adjustCam;
    public GameObject interactCamera;
    Vector3 cameraBasePos;
    Vector3 cameraBaseRot;
    public float speed;
    Vector3 newPosCamera;
    float camMoveSpeed;

    [Header("Other")]
    GameObject uiManager;
    float stoppingDis;


    public void SeroundPress(string name, string info, Transform t)
    {
        newPosCamera = t.position + adjustCam;
        StartCoroutine(Spread(newPosCamera));
    }

    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager");
        interactCamera.SetActive(false);

        cameraBasePos = transform.position + new Vector3(0, 0, -1.5f);

        stoppingDis = 0.01f;
    }

    public IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(interactCamera.transform.position, v) >= stoppingDis)
        {
            Debug.Log("na while");
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }
        GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
        panel.SetActive(!panel.activeSelf);
        if (stoppingDis <= 0.01)
        {
            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
            uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
            uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);
        }
    }
    public void StartTheSpreadBack()
    {
        StartCoroutine(Spread(cameraBasePos));
    }
}
