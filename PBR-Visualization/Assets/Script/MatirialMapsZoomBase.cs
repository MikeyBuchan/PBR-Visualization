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
    public bool allowRotation;
    Quaternion standardcamRotation;
    public bool mayZoom = true;

    [Header("UI")]
    public GameObject namePanel;
    public GameObject discriptionPanel;
    public GameObject extraDiscriptionPanel;
    public GameObject otherName;

    public void Update()
    {
        if (allowRotation)
        {
            Vector3 lookOffset = new Vector3((Input.mousePosition.x - (Screen.width / 2)) / Screen.width, (-Input.mousePosition.y - (Screen.height / 2)) / Screen.height, camRotationOfset);
            interactCamera.transform.LookAt(transform.position - (lookOffset * camRotationAmount));
        }
        else
            interactCamera.transform.rotation = standardcamRotation;
    }

    public void SeroundPress(string name, string info, string extraInfo, Transform t)
    {
        newPosCamera = t.position + adjustCam;

        if (mayZoom == true)
        {
            namePanel.GetComponentInChildren<Text>().text = name;
            discriptionPanel.GetComponentInChildren<Text>().text = info;
            extraDiscriptionPanel.GetComponentInChildren<Text>().text = extraInfo;
            otherName.GetComponentInChildren<Text>().text = name;

            StartCoroutine(Spread(newPosCamera));
        }
        else
        {
            Debug.Log("al ingezoomed");
        }
    }


    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager");
        interactCamera.SetActive(false);

        cameraBasePos = transform.position + baseCamAdjustment;
        standardcamRotation = interactCamera.transform.rotation;
        stoppingDis = 0.01f;
    }

    public IEnumerator Spread(Vector3 v)
    {
        allowRotation = !allowRotation;
        while (Vector3.Distance(interactCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }

        GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
        panel.SetActive(!panel.activeSelf);
        mayZoom = !mayZoom;
        //ergens bool 
        //als je trug gaat de ui uit
        if (stoppingDis <= 0.01)
        {
            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
            uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
            uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);

            GameObject g = uiManager.GetComponent<UIManager>().backToPlayerButton;
            g.SetActive(!g.activeSelf);
        }
    }
    public void StartTheSpreadBack()
    {
        StartCoroutine(Spread(cameraBasePos));
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + baseCamAdjustment, 0.2f);
    }
}
