using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMapsChange : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = mat1;
        Debug.Log("Start this script hehehe");
    }

    private void Update()
    {
        SwitchMat();
    }

    public void SwitchMat()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("pressed K");
            if (gameObject.GetComponent<InteractionMaterialChanger>().mayMatChange == true)
            {
                Debug.Log("for the if");
                if (mesh.material == mat1)
                {
                    mesh.material = mat2;
                    Debug.Log("After Switch");
                }
                else
                {
                    mesh.material = mat1;
                }
            }
        }
        //andere manier van aanroepen zoeken 
        //mis een button
    }
}
