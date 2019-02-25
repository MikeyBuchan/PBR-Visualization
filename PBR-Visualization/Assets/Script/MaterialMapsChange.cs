using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MaterialMapsChange : MonoBehaviour
{
    //JELMER BEDOELD MET ALPHAS DE TEXTURE MAPS
    Renderer mesh;
    int currIndex;

    [Header("Rotation")]
    public float speed;
    Quaternion startRot;
    public float lerpSpeed;

    [Header("Models")]
    public List<Mesh> modelList = new List<Mesh>();
    public List<NamedTexture> AlphasList = new List<NamedTexture>();

    [Header("CustomColor")]
    public Color currentColor;
    public Gradient gradient;
    public Slider ColorSlider, multiplySlider;

    [Header("ShaderNames")]
    public string albedoName;
    public string albedoColorName;
    public string albedoColorMultiplyName;

    [Header("Other")]
    public Dropdown alphaDropdown;

    void Start()
    {
        mesh = GetComponent<Renderer>();
        startRot = gameObject.transform.rotation;
        gameObject.GetComponent<MeshFilter>().mesh = modelList[0];

        CoppleDropdownList();
    }

    void Update()
    {
        //rotate
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

    public void SwitchMaterialMap(int amount)
    {
        mesh.material.SetTexture(albedoName, AlphasList[amount].texture);
    }

    public void ChangeSlider()
    {
        Color color = gradient.Evaluate(ColorSlider.value);
        Color tempColor = new Color(color.r * multiplySlider.value, color.g * multiplySlider.value, color.b * multiplySlider.value);
        currentColor = tempColor;
        Debug.Log(gradient.Evaluate(ColorSlider.value));
    }

    public void CoppleDropdownList()
    {
        List<string> fillName = new List<string>();
        foreach (var name in AlphasList)
        {
            fillName.Add(name.name);
        }

        alphaDropdown.AddOptions(fillName);
    }

    [System.Serializable]
    public class NamedTexture
    {
        public string name;
        public Texture2D texture;

        public NamedTexture(string _name, Texture2D _texture)
        {
            name = _name;
            texture = _texture;
        }
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



}

    */
}