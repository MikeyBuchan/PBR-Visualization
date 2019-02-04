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
    public float speed;
    public float stoppingDis;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        newPosCamera = transform.position + adjustCam;
        cameraBasePos = mainCamera.transform.position;
    }

    void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("click " + gameObject.name);
            Debug.Log(Vector3.Distance(cameraBasePos, newPosCamera));
            //moving
            StartCoroutine(Spread(newPosCamera));
            //mainCamera.transform.position = newPosCamera;
            //UItrue
            GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(true);
        }
    }

    public void ZoomOut()
    {
        mainCamera.transform.position = cameraBasePos;
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backButton.SetActive(false);
    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(cameraBasePos, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(cameraBasePos, newPosCamera, camMoveSpeed);
            yield return null;
        }
    }
}
