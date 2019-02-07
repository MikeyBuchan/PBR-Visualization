using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoomBase : MonoBehaviour
{
    [Header("Camera")]
    public Vector3 adjustCam;
    Vector3 cameraBasePos;
    public float speed;
    GameObject mainCamera;
    Vector3 newPosCamera;
    float camMoveSpeed;

    [Header("Other")]
    GameObject uiManager;
    float stoppingDis;
    bool advancedBool;

    public void SeroundPress(string name, string info, Transform t)
    {
        //als die is ingedrukt info moet hier
        Debug.Log("start co");
        newPosCamera = t.position + adjustCam;
        StartCoroutine(Spread(t.position));

    }

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        uiManager = GameObject.FindWithTag("UiManager");
 
        cameraBasePos = gameObject.transform.position;

        stoppingDis = 0.01f;
    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(mainCamera.transform.position, v) >= stoppingDis)
        {
            Debug.Log("na while");
            camMoveSpeed = speed * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }
        GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
        panel.SetActive(!panel.activeSelf);
        if (stoppingDis <= 0.01)
        {
            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
            uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
        }
    }

}


/*
        public void AdvanceTextButton()
    {
        uiManager.GetComponent<UIManager>().infoPbrAdvanced.SetActive(true);
        uiManager.GetComponent<UIManager>().advancedButton.SetActive(false);
        uiManager.GetComponent<UIManager>().infoNormal.SetActive(false);
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
            uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
            advancedBool = false;
        }

    }


*/
