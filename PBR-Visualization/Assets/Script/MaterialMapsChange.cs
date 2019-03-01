using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MaterialMapsChange : MonoBehaviour
{
    //JELMER BEDOELD MET ALPHAS DE TEXTURE MAPS
    Renderer mesh;
    MeshRenderer RMesh;
    int currIndex;

    [Header("Rotation")]
    public float speed;
    public float lerpSpeed;
    Quaternion startRot;

    [Header("lists")]
    public List<Mesh> modelList = new List<Mesh>();
    public List<NamedTexture> alphasList = new List<NamedTexture>();
    public List<NamedTexture> metallicMapList = new List<NamedTexture>();
    public List<NamedTexture> emissionMapList = new List<NamedTexture>();

    public List<InvertBoolClass> invertBoolList = new List<InvertBoolClass>();

    public List<Sliders> sliderList = new List<Sliders>();
    public List<OneSlider> oneSliderList = new List<OneSlider>();

    [Header("CustomColor")]
    public Gradient gradient;

    [Header("ShaderNames")]
    public string albedoName;
    public string metallicName;
    public string emissionName;

    [Header("Dropdown")]
    public Dropdown alphaDropdown;
    public Dropdown metallicDropdown;
    public Dropdown emissionDropdown;

    void Start()
    {
        mesh = GetComponent<Renderer>();
        RMesh = GetComponent<MeshRenderer>();
        startRot = gameObject.transform.rotation;
        gameObject.GetComponent<MeshFilter>().mesh = modelList[0];

        CoppleDropdownListAlbedoMaps();
        CoppleDropdownListmatellicMaps();
        CoppleDropdownListEmissionMaps();
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
    //model switch
    public void ChangeModel()
    {
        currIndex++;
        if (currIndex>= modelList.Count)
        {
            currIndex = 0;
        }
        transform.GetComponent<MeshFilter>().mesh = modelList[currIndex];
    }
    //albedo Maps
    public void SwitchMaterialMap(int amount)
    {
        mesh.material.SetTexture(albedoName, alphasList[amount].texture);
        Debug.Log(albedoName);
        Debug.Log(metallicMapList[amount].texture);
    }

    public void ChangeSliderColor(int listNeeded)
    {
        Slider colorSlider = sliderList[listNeeded].slider;
        Slider multiplySlider = sliderList[listNeeded].amount;

        Color color = gradient.Evaluate(colorSlider.value);
        Color tempColor = new Color(color.r * multiplySlider.value, color.g * multiplySlider.value, color.b * multiplySlider.value);
        mesh.material.SetColor(sliderList[listNeeded].shaderName, tempColor);
    }
    //matelic Maps
    public void SwitchMatelicMap(int amount)
    {
        mesh.material.SetTexture(metallicName, metallicMapList[amount].texture);
        Debug.Log(metallicName);
        Debug.Log(metallicMapList[amount].texture);
    }

    public void ChangeMatelValue(int list)
    {
        Slider matel = oneSliderList[list].slider;

        mesh.material.SetFloat(oneSliderList[list].nameShader, matel.value);
    }
    //emission Maps
    public void SwitchEmissionMap(int amount)
    {
        mesh.material.SetTexture(emissionName, emissionMapList[amount].texture);
        Debug.Log(emissionName);
        Debug.Log(metallicMapList[amount].texture);
    }

    //iets met de muis en de slider

    //droplist difred albedo
    public void CoppleDropdownListAlbedoMaps()
    {
        List<string> fillName = new List<string>();
        foreach (var name in alphasList)
        {
            fillName.Add(name.name);
        }

        alphaDropdown.AddOptions(fillName);
    }
    public void CoppleDropdownListmatellicMaps()
    {
        List<string> tempName = new List<string>();
        foreach (var itemName in metallicMapList)
        {
            tempName.Add(itemName.name);
        }
        metallicDropdown.AddOptions(tempName);
    }
    public void CoppleDropdownListEmissionMaps()
    {
        List<string> vs = new List<string>();
        foreach (var item in emissionMapList)
        {
            vs.Add(item.name);
        }
        emissionDropdown.AddOptions(vs);
    }

    //invert the bool
    public void InvertBoolian(int whichOne)
    {
        if (invertBoolList[whichOne].invert == 0)
        {
            invertBoolList[whichOne].invert = 1;
            mesh.material.SetInt(invertBoolList[whichOne].boolNameShader, invertBoolList[whichOne].invert);
        }
        else
        {
            invertBoolList[whichOne].invert = 0;
            mesh.material.SetInt(invertBoolList[whichOne].boolNameShader, invertBoolList[whichOne].invert);
        }
    }
    
    //albedo
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
    //two slider
    [System.Serializable]
    public class Sliders
    {
        public Slider slider, amount;
        public string shaderName;

    }
    //one slider
    [System.Serializable]
    public class OneSlider
    {
        public Slider slider;
        public string nameShader;

    }
    //invert
    [System.Serializable]
    public class InvertBoolClass
    {
        public int invert;
        public string boolNameShader;

    }

    /*
    ///
    invert bool list //cons
    copple names to list
    ///
    function knop
    die juiste aanropet
    revert
    ///


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


}

    */
}