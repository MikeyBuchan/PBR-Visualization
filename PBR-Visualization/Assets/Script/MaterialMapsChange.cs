using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMapsChange : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    Renderer mesh;

    void Start()
    {
        mesh = GetComponent<Renderer>();
        mesh.material = mat1;
    }

    public void SwitchMat()
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

    public void ChangeMatelic(float metallic)
    {
        mesh.material.SetFloat("_Metallic", metallic);
    }
}