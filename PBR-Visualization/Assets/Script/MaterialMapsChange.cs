using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMapsChange : MonoBehaviour
{
    Renderer mesh;
    int currIndex;

    [Header("Rotation")]
    public float speed;
    Quaternion startRot;
    public float lerpSpeed;

    [Header("Models")]
    public List<Mesh> modelList = new List<Mesh>();
    
    [Header("Other")]
    public Material mat1;
    public Material mat2;

    void Start()
    {
        mesh = GetComponent<Renderer>();
        mesh.material = mat1;
        startRot = gameObject.transform.rotation;
        gameObject.GetComponent<MeshFilter>().mesh = modelList[0];
    }

    void Update()
    {
        if (gameObject.GetComponent<InteractionMaterialChanger>().mayMatChange == true)
        {
            RotateObject();
        }
        else if (gameObject.transform.rotation != startRot)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, Time.deltaTime * lerpSpeed);
        }
    }

    void RotateObject()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed, Space.World);
        }
    }

    public void ChangeModel()
    {
        currIndex++;
        if (currIndex>= modelList.Count)
        {
            currIndex = 0;
        }
        transform.GetComponent<MeshFilter>().mesh = modelList[currIndex];
    }
    
    /*public void SwitchMat()
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
    */
}