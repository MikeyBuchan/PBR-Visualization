using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    GameObject mainCamera;
    Vector3 newPosCamera;
    Vector3 cameraBasePos;
    public Vector3 adjustCam;
    float camMoveSpeed;
    float stoppingDis;
    public float speed;
    bool mayZoom;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        newPosCamera = transform.position + adjustCam;
        cameraBasePos = mainCamera.transform.position;
        mayZoom = true;
        stoppingDis = 0.01f;
    }

    void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (mayZoom == true)
            {
                //moving
                StartCoroutine(Spread(newPosCamera));
                //UItrue
                GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(true);
                mayZoom = false;
            }
        }
    }

    public void ZoomOut()
    {
        mainCamera.transform.position = cameraBasePos;
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(false);
        mayZoom = true;
        //same zoomout
    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(mainCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }
        Debug.Log("done");
    }
}
