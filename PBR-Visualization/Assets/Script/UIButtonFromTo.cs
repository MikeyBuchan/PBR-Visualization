using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFromTo : MonoBehaviour
{
    public GameObject[] from;
    public GameObject[] to;

    public void OnButtonPress()
    {
        foreach (GameObject obj in from)
            obj.SetActive(false);
        foreach (GameObject obj in to)
            obj.SetActive(true);
    }
}
