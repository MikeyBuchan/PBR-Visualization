using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject infoAllPbr;
    public GameObject infoNormal;
    public GameObject infoPbrAdvanced;

    public GameObject interactDisplay;

    public GameObject advancedButton;
    public GameObject normalInfoButton;
    public GameObject zoomOutButton;
    public GameObject backToPlayerButton;

    public GameObject mBase;
    GameObject mainCamera;
    bool advancedBool;

    void Start()
    {
        infoAllPbr.SetActive(false);
        infoNormal.SetActive(false);
        infoPbrAdvanced.SetActive(false);
        interactDisplay.SetActive(false);

        advancedButton.SetActive(false);
        normalInfoButton.SetActive(false);
        zoomOutButton.SetActive(false);
        backToPlayerButton.SetActive(false);
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    public void ButtomZoomOut()
    {
        if (advancedBool == false)
        {
            mBase.GetComponent<MatirialMapsZoomBase>().StartTheSpreadBack();
        }
    }

    public void ButtonAdvanceTextButton()
    {
        infoPbrAdvanced.SetActive(true);
        infoNormal.SetActive(false);

        zoomOutButton.SetActive(false);
        advancedButton.SetActive(false);
        normalInfoButton.SetActive(true);
        backToPlayerButton.SetActive(false);

        advancedBool = true;
    }

    public void ButtonBackToNormalUI()
    {
        infoPbrAdvanced.SetActive(false);
        infoNormal.SetActive(true);
        normalInfoButton.SetActive(false);
        zoomOutButton.SetActive(true);

        backToPlayerButton.SetActive(false);
        advancedButton.SetActive(true);
        advancedBool = false;
    }

    public void ButtonBackToPlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
        interactDisplay.SetActive(false);
        mBase.GetComponent<MatirialMapsZoomBase>().interactCamera.SetActive(false);
        mBase.GetComponent<MatirialMapsZoomBase>().allowRotation = true;
        mainCamera.SetActive(true);
        infoAllPbr.SetActive(false);
    }
}
