using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialMapsZoomBase : MonoBehaviour
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
    public Vector3 baseCamAdjustmentMiddleObject;
    public float camRotationAmount;

    [Header("Other")]
    GameObject uiManager;
    float stoppingDis;
    [HideInInspector]
    public bool allowRotation = false;
    public bool zoomdIn = false;
    Quaternion standardcamRotation;

    public bool zoom = true;
    bool maySwitchSmallBalls = false;

    public int myChildNumber;

    public List<Transform> childList = new List<Transform>();

    [Header("UI")]
    public GameObject namePanel;
    public GameObject discriptionPanel;
    public GameObject extraDiscriptionPanel;
    public GameObject otherName;
    public GameObject backButtonMiddleObject;

    //set values
    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager");
        interactCamera.SetActive(false);
        backButtonMiddleObject.SetActive(false);

        cameraBasePos = transform.position + baseCamAdjustment;
        standardcamRotation = interactCamera.transform.rotation;
        stoppingDis = 0.01f;

        foreach (Transform item in transform)
        {
            if (item.GetComponent<MaterialMapsZoom>())
            {
                childList.Add(item);
            }
        }
    }
    //alouw the rotation
    public void Update()
    {
        if (maySwitchSmallBalls == true)
        {
            Next();
        }
        Debug.Log(uiManager.GetComponent<UIManager>().zoomOutButton.activeSelf);
        //Debug.Log("zoom = " + zoom);
        //Debug.Log(allowRotation);

        if (allowRotation)
        {
            Vector3 lookOffset = new Vector3((Input.mousePosition.x - (Screen.width / 2)) / Screen.width, (-Input.mousePosition.y - (Screen.height / 2)) / Screen.height, camRotationOfset);
            interactCamera.transform.LookAt(transform.position - (lookOffset * camRotationAmount));
        }
        else
            interactCamera.transform.rotation = standardcamRotation;
    }
    //witch one is pressed and set the text
    public void SeroundPress(int t)
    {
        newPosCamera = childList[t].transform.position + adjustCam;
        MaterialMapsZoom MMZ = childList[t].GetComponent<MaterialMapsZoom>();
        Debug.Log(newPosCamera);

        namePanel.GetComponentInChildren<Text>().text = MMZ.nameObj;
        discriptionPanel.GetComponentInChildren<Text>().text = MMZ.infoObj;
        extraDiscriptionPanel.GetComponentInChildren<Text>().text = MMZ.extraInfoObj;
        otherName.GetComponentInChildren<Text>().text = MMZ.nameObj;

        if (zoom == true)
        {
            StartCoroutine(Spread(newPosCamera, false));
            zoom = false;
        }

    }
    //zoom in and out
    public IEnumerator Spread(Vector3 v, bool b)
    {
        if (b)
        {
            GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
            panel.SetActive(false);
            zoom = true;
            maySwitchSmallBalls = false;
            allowRotation = true;
            zoomdIn = false;

            Debug.Log("panel 2 =" + panel.activeSelf);

            GameObject g = uiManager.GetComponent<UIManager>().backToPlayerButton;
            g.SetActive(true);
            if (stoppingDis <= 0.01)
            {
                uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
                uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
                uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);
            }
        }

        //allowRotation = !allowRotation;
        while (Vector3.Distance(interactCamera.transform.position, v) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, v, camMoveSpeed);
            yield return null;
        }

        if (!b)
        {
            GameObject panel = uiManager.GetComponent<UIManager>().infoAllPbr;
            panel.SetActive(true);
            zoom = true;
            maySwitchSmallBalls = true;
            allowRotation = false;

            Debug.Log("panel 1 =" + panel.activeSelf);

            GameObject g = uiManager.GetComponent<UIManager>().backToPlayerButton;
            g.SetActive(false);
            if (stoppingDis <= 0.01)
            {
                uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
                uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);
                uiManager.GetComponent<UIManager>().zoomOutButton.SetActive(true);
            }
        
        }
        if (zoom == false)
        {
            zoom = true;
        }
    }

    //start te rotation back
    public void StartTheSpreadBack()
    {
        if (zoom == true)
        {
            StartCoroutine(Spread(cameraBasePos,true));
            zoom = false;
            backButtonMiddleObject.SetActive(false);
        }
    }

    //switch whit the button or arrow keys
    void Next()
    {
        if (maySwitchSmallBalls == true)
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                myChildNumber += ((Input.GetAxisRaw("Horizontal") > 0) ? 1 : -1);
                if (myChildNumber >= childList.Count)
                    myChildNumber = 0;
                else if (myChildNumber < 0)
                    myChildNumber = childList.Count - 1;
                SeroundPress(myChildNumber);
                Debug.Log(myChildNumber);

            }
        }
    }

    private void OnMouseDown()
    {
        if (zoom == true)
        {
            StartCoroutine(ZoomMiddelObject(transform));
        }
    }

    IEnumerator ZoomMiddelObject(Transform transform)
    {
        while (Vector3.Distance(interactCamera.transform.position, transform.position + baseCamAdjustmentMiddleObject) >= stoppingDis)
        {
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, transform.position + baseCamAdjustmentMiddleObject, camMoveSpeed);
            yield return null;
        }
        GameObject game = uiManager.GetComponent<UIManager>().backToPlayerButton;
        game.SetActive(false);
        if (stoppingDis <= 0.1)
        {
            backButtonMiddleObject.SetActive(true);
        }

    }


    //realtime check wheare the camera is
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + baseCamAdjustment, 0.2f);
    }

    
}
