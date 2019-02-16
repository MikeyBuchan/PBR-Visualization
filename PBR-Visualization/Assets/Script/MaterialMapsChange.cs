using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMapsChange : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    Renderer mesh;

    private void Start()
    {
        mesh = GetComponent<Renderer>();
        mesh.material = mat1;
    }

    private void Update()
    {
        SwitchMat();

    }

    public void SwitchMat()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (gameObject.GetComponent<InteractionMaterialChanger>().mayMatChange == true)
            {
                if (mesh.sharedMaterial == mat1)
                {
                    mesh.material = mat2;
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
