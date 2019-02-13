using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatirialMapsZoomBase : MonoBehaviour
{
    [Header("Camera")]
    public Vector3 adjustCam;
    public GameObject interactCamera;
    public float camRotationOfset;
    Vector3 cameraBasePos;
    Vector3 cameraBaseRot;
    public float speed;
    Vector3 newPosCamera;
    float camMoveSpeed;
    public Vector3 baseCamAdjustment;
    public float camRotationAmount;

    [Header("Other")]
    GameObject uiManager;
    float stoppingDis;
    [HideInInspector]
    public bool allowRotation = false;
    Quaternion standardcamRotation;
    public bool mayZoom = true;
    public bool zoom = true;

    [Header("UI")]
    public GameObject namePanel;
    public GameObject discriptionPanel;
    public GameObject extraDiscriptionPanel;
    public GameObject otherName;

    //alouw the rotation
    public void Update()
    {
        Debug.Log("zoom = " + zoom);
        if (allowRotation)
        {
            Vector3 lookOffset = new Vector3((Input.mousePosition.x - (Screen.width / 2)) / Screen.width, (-Input.mousePosition.y - (Screen.height / 2)) / Screen.height, camRotationOfset);
            interactCamera.transform.LookAt(transform.position - (lookOffset * camRotationAmount));
        }
        else
            interactCamera.transform.rotation = standardcamRotation;
    }
    //witch one is pressed and set the text
    public void SeroundPress(string name, string info, string extraInfo, Transform t)
    {
        newPosCamera = t.position + adjustCam;

        if (mayZoom == true)
        {
            namePanel.GetComponentInChildren<Text>().text = name;
            discriptionPanel.GetComponentInChildren<Text>().text = info;
            extraDiscriptionPanel.GetComponentInChildren<Text>().text = extraInfo;
            otherName.GetComponentInChildren<Text>().text = name;

            if (zoom == true)
            {
                StartCoroutine(Spread(newPosCamera,false));
                zoom = false;
            }
        }
    }
    //set values
    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager");
        interactCamera.SetActive(false);

        cameraBasePos = transform.position + baseCamAdjustment;
        standardcamRotation = interactCamera.transform.rotation;
        stoppingDis = 0.01f;
    }
    //zoom in and out
    public IEnumerator Spread(Vector3 v, bool b)
    {
        if (b)
        {
            GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
            panel.SetActive(!panel.activeSelf);
            mayZoom = !mayZoom;

            GameObject g = uiManager.GetComponent<UIManager>().backToPlayerButton;
            g.SetActive(!g.activeSelf);
            if (stoppingDis <= 0.01)
            {
                uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
                uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
                uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);

            }
        }

        allowRotation = !allowRotation;
        while (Vector3.Distance(interactCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }

        if (!b)
        {
            GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
            panel.SetActive(!panel.activeSelf);
            mayZoom = !mayZoom;

            GameObject g = uiManager.GetComponent<UIManager>().backToPlayerButton;
            g.SetActive(!g.activeSelf);
            if (stoppingDis <= 0.01)
            {
                uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
                uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
                uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);

            }
        }
        zoom = !zoom;
    }
    //start te rotation back
    public void StartTheSpreadBack()
    {
        if (zoom == true)
        {
            StartCoroutine(Spread(cameraBasePos,true));
        }
    }
    //realtime check wheare the camera is
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + baseCamAdjustment, 0.2f);
    }
}
