using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject backButton;

    void Start()
    {
        backButton.SetActive(false);
    }

}
