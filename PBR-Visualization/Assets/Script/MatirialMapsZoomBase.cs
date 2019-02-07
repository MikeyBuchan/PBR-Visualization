using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatirialMapsZoomBase : MonoBehaviour
{
    [Header("Camera")]
    public Vector3 adjustCam;
    public GameObject interactCamera;
    Vector3 cameraBasePos;
    Vector3 cameraBaseRot;
    public float speed;
    Vector3 newPosCamera;
    float camMoveSpeed;

    [Header("Other")]
    GameObject uiManager;
    float stoppingDis;
    bool advancedBool;

    public void SeroundPress(string name, string info, Transform t)
    {
        newPosCamera = t.position + adjustCam;
        StartCoroutine(Spread(newPosCamera));
    }

    void Start()
    {
        uiManager = GameObject.FindWithTag("UiManager");
        interactCamera.SetActive(false);

        cameraBasePos = transform.position + new Vector3(0, 0, -1.5f);

        stoppingDis = 0.01f;
    }

    IEnumerator Spread(Vector3 v)
    {
        while (Vector3.Distance(interactCamera.transform.position, v) >= stoppingDis)
        {
            Debug.Log("na while");
            camMoveSpeed = speed * Time.deltaTime;
            interactCamera.transform.position = Vector3.MoveTowards(interactCamera.transform.position, v, camMoveSpeed);
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

    public void ButtonAdvanceTextButton()
    {
        uiManager.GetComponent<UIManager>().infoPbrAdvanced.SetActive(true);
        uiManager.GetComponent<UIManager>().infoNormal.SetActive(false);

        uiManager.GetComponent<UIManager>().advancedButton.SetActive(false);
        advancedBool = true;
    }

    public void ButtomZoomOut()
    {
        if (advancedBool == false)
        {
            StartCoroutine(Spread(cameraBasePos));
        }
        else
        {
            uiManager.GetComponent<UIManager>().infoPbrAdvanced.SetActive(false);
            uiManager.GetComponent<UIManager>().infoNormal.SetActive(true);

            uiManager.GetComponent<UIManager>().advancedButton.SetActive(true);
            advancedBool = false;
        }

    }
}
