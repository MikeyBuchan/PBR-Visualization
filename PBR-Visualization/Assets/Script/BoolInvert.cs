using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolInvert : MonoBehaviour
{
    public GameObject switchMat;

    public void BoolInvertFunction()
    {
        switchMat.GetComponent<InteractionMaterialChanger>().mayMatChange = false;

        Debug.Log("bool false");
    }
    public void BoolInvertFunctionFalse()
    {
        switchMat.GetComponent<InteractionMaterialChanger>().mayMatChange = true;
        Debug.Log("bool true");
    }
}
