using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    GameObject mainCamera;
    Vector3 newPosCamera;
    public Vector3 adjustCam;
    Vector3 mainCameraBasePos;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        newPosCamera = transform.position + adjustCam;
        mainCameraBasePos = mainCamera.transform.position;
    }

    void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("click " + gameObject.name);
            //zoom
            mainCamera.transform.position = newPosCamera;
            GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(true);
        }
    }

    public void ZoomOut()
    {
        mainCamera.transform.position = mainCameraBasePos;
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(false);
    }
}
