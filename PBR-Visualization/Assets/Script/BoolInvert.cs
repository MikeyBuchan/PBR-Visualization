using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolInvert : MonoBehaviour
{
    public GameObject mBase;
    bool b;

    // Start is called before the first frame update
    void Start()
    {
        b = mBase.GetComponent<MaterialMapsZoomBase>().zoomdIn;
    }

    public void BoolInvertFunction()
    {
        b = !b;
        Debug.Log("bool invert");
    }
}
