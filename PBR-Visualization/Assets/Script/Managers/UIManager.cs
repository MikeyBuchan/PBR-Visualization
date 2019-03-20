using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject infoAllPbr;
    public GameObject infoNormal;
    public GameObject infoPbrAdvanced;
    [Header("Buttons")]
    public GameObject advancedButton;
    public GameObject normalInfoButton;
    public GameObject zoomOutButton;
    public GameObject backToPlayerButton;

    public GameObject switchValueEmpty;
    [Header("Other")]
    public GameObject interactDisplay;
    public GameObject mBase;
    public GameObject mChange;
    GameObject mainCamera;
    public GameObject optionsMenu;
    bool advancedBool;

    private void Start()
    {
        infoAllPbr.SetActive(false);
        infoNormal.SetActive(false);
        infoPbrAdvanced.SetActive(false);
        interactDisplay.SetActive(false);

        advancedButton.SetActive(false);
        normalInfoButton.SetActive(false);
        zoomOutButton.SetActive(false);
        mainCamera = GameObject.FindWithTag("MainCamera");
        backToPlayerButton.SetActive(false);
        switchValueEmpty.SetActive(false);
        optionsMenu.SetActive(false);
    }

    private void Update()
    {
        OtherOptions();
    }

    public void ButtomZoomOut()
    {
        if (advancedBool == false)
        {
            mBase.GetComponent<MaterialMapsZoomBase>().StartTheSpreadBack();
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

        backToPlayerButton.SetActive(false);
    }

    public void ButtonBackToNormalUI()
    {
        infoPbrAdvanced.SetActive(false);
        infoNormal.SetActive(true);
        normalInfoButton.SetActive(false);
        zoomOutButton.SetActive(true);

        advancedButton.SetActive(true);
        advancedBool = false;

        backToPlayerButton.SetActive(false);
    }

    public void ButtonBackToPlayer()
    {
        mBase.GetComponent<MaterialMapsZoomBase>().interactCamera.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
        interactDisplay.SetActive(false);
        mBase.GetComponent<MaterialMapsZoomBase>().allowRotation = false;
        mainCamera.SetActive(true);
        infoAllPbr.SetActive(false);

        backToPlayerButton.SetActive(false);
    }

    public void ButtonModelSwitch()
    {
        mChange.GetComponent<MaterialMapsChange>().ChangeModel();
        Debug.Log("Clicked Button ModelSwitch");
    }

    public void BackToPlayerButtonV2()
    {
        mChange.GetComponent<InteractionMaterialChanger>().interactCamera.SetActive(false);
        mainCamera.SetActive(true);
        mChange.GetComponent<InteractionMaterialChanger>().mayMatChange = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
        switchValueEmpty.SetActive(false);
    }

    public void OtherOptions()
    {
        if (Input.GetButtonDown("Options"))
        {
            Debug.Log("neuhwfbubuwb");
            optionsMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BackOterOptions()
    {
        Debug.Log("enbubv");
        optionsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToOptions()
    {
        Debug.Log("Go TO");
    }

}