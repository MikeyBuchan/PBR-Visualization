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

    public GameObject mBase;
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

        advancedBool = true;
    }

    public void ButtonBackToNormalUI()
    {
        infoPbrAdvanced.SetActive(false);
        infoNormal.SetActive(true);
        normalInfoButton.SetActive(false);
        zoomOutButton.SetActive(true);

        advancedButton.SetActive(true);
        advancedBool = false;
    }
}
