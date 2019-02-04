using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    public Vector3 adjustCam;
    public float speed;
    GameObject mainCamera;
    Vector3 newPosCamera;
    Vector3 cameraBasePos;
    float camMoveSpeed;
    float stoppingDis;
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
                StartCoroutine(Spread(newPosCamera));
                GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(true);
                mayZoom = false;
            }
        }
    }

    public void ZoomOut()
    {
        StartCoroutine(Spread(cameraBasePos));
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(false);
        mayZoom = true;
    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(mainCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }
    }
}
