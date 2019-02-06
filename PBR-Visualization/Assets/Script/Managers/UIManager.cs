using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject infoPbr;
    public GameObject infoPbrAdvanced;
    public GameObject advancedButton;
    public GameObject interactDisplay;

    void Start()
    {
        infoPbr.SetActive(false);
        infoPbrAdvanced.SetActive(false);
        advancedButton.SetActive(false);
        interactDisplay.SetActive(false);
    }

}
