using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    public Vector3 adjustCam;
    public float speed;
    GameObject mainCamera;
    GameObject uiManager;
    Vector3 newPosCamera;
    Vector3 cameraBasePos;
    float camMoveSpeed;
    float stoppingDis;
    bool advancedBool;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        uiManager = GameObject.FindWithTag("UiManager");
        newPosCamera = transform.position + adjustCam;
        cameraBasePos = mainCamera.transform.position;
        stoppingDis = 0.01f;
    }

    void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Spread(newPosCamera));
        }
    }

    public void AdvanceTextButton()
    {
        uiManager.GetComponent<UIManager>().infoPbrAdvanced.SetActive(true);
        uiManager.GetComponent<UIManager>().advancedButton.SetActive(false);
        advancedBool = true;
    }

    public void ZoomOut()
    {
        if (advancedBool == false)
        {
            StartCoroutine(Spread(cameraBasePos));
        }
        else
        {
            uiManager.GetComponent<UIManager>().infoPbrAdvanced.SetActive(false);
            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
            advancedBool = false;
        }

    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(mainCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }
        GameObject panel = uiManager.GetComponent<UIManager>().infoPbr;
        panel.SetActive(!panel.activeSelf);
        if (stoppingDis <= 0.01)
        {
            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
        }
    }
}
