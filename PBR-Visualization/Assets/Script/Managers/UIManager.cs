using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool advancedBool;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

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
        OtherOptionsOpen();
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
        mBase.GetComponent<MaterialMapsZoomBase>().zoomdIn = false;

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
        mBase.GetComponent<MaterialMapsZoomBase>().zoomdIn = true;

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
        Cursor.lockState = CursorLockMode.Locked;
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OtherOptionsOpen()
    {
        if (Input.GetButtonDown("Options") && optionsMenu.activeSelf == false)
        {
            Debug.Log("neuhwfbubuwb");
            optionsMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
        }
        else if(Input.GetButtonDown("Options") && optionsMenu.activeSelf == true)
        {
            optionsMenu.SetActive(false);
            if (mBase.GetComponent<MaterialMapsZoomBase>().allowRotation == true || mChange.GetComponent<InteractionMaterialChanger>().mayMatChange == true)
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void OterOptionsClose()
    {
        Debug.Log("enbubv");
        optionsMenu.SetActive(false);
        if (mBase.GetComponent<MaterialMapsZoomBase>().allowRotation == true || mChange.GetComponent<InteractionMaterialChanger>().mayMatChange == true)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void YesQuit()
    {
        Debug.Log("Player Quit");
        Application.Quit();
    }

}