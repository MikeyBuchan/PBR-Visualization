using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacks : MonoBehaviour
{
    public GameObject ppObj;

    private void Start()
    {
        ppObj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButton("Hold") && Input.GetButtonDown("Invert"))
        {
            Debug.Log("Invert");
            ppObj.SetActive(!ppObj.activeSelf);
        }
    }
}
