using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoom : MonoBehaviour
{
    public Vector3 adjustCam;
    public float speed;
    public Transform parent;
    GameObject mainCamera;
    GameObject uiManager;
    Vector3 newPosCamera;
    float camMoveSpeed;
    float stoppingDis;
    bool advancedBool;
    public Vector3 cameraBasePos;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        uiManager = GameObject.FindWithTag("UiManager");
        newPosCamera = transform.position + adjustCam;
        cameraBasePos = gameObject.transform.parent.gameObject.transform.position;
        stoppingDis = 0.01f;
    }
    void OnMouseDown()
    {
        if (gameObject.GetComponentInChildren<PlayerLook>().freeMove == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Spread(newPosCamera));
            }
        }
        else
        {
            Debug.Log("false");
        }
    }

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

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(mainCamera.transform.position, v) >= stoppingDis)
        {
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
