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

    public List<InvertBoolClass> invertBoolList = new List<InvertBoolClass>();

    public List<Sliders> sliderList = new List<Sliders>();
    public List<OneSlider> oneSliderList = new List<OneSlider>();

    [Header("CustomColor")]
    public Gradient gradient;

    [Header("ShaderNames")]
    public string albedoName;
    public string metallicName;
    public string emissionName;
    public string smoothnessName;
    public string normalName;
    public string ambientOcclusionName;

    [Header("Dropdown")]
    public List<Dropdown> alphaDorpdownList = new List<Dropdown>();

    void Start()
    {
        mesh = GetComponent<Renderer>();
        RMesh = GetComponent<MeshRenderer>();
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
        mesh.material.SetTexture(metallicName, alphasList[amount].texture);
        Debug.Log(metallicName);
        Debug.Log(alphasList[amount].texture);
    }

    public void ChangeOneSliderValue(int list)
    {
        Slider one = oneSliderList[list].slider;

        mesh.material.SetFloat(oneSliderList[list].nameShader, one.value);
    }
    //emission Maps
    public void SwitchEmissionMap(int amount)
    {
        mesh.material.SetTexture(emissionName, alphasList[amount].texture);
        Debug.Log(emissionName);
    }

    //smoothness maps
    public void SwitchSmoothnessMap(int amount)
    {
        mesh.material.SetTexture(smoothnessName, alphasList[amount].texture);
        Debug.Log(smoothnessName);
    }
    //Normal maps
    public void SwitchNormalMap(int amount)
    {
        mesh.material.SetTexture(normalName, alphasList[amount].texture);
        Debug.Log(normalName);
    }
    //Ambient Occulusion
    public void SwitchAmbientOcclusion(int amount)
    {
        mesh.material.SetTexture(ambientOcclusionName, alphasList[amount].texture);
        Debug.Log(ambientOcclusionName);
    }

    //iets met de muis en de slider

    //droplist difred albedo
    public void CoppleDropdownList()
    {
        List<string> fillName = new List<string>();
        foreach (var name in alphasList)
        {
            fillName.Add(name.name);
        }
        foreach (var dropDown in alphaDorpdownList)
        {
            dropDown.AddOptions(fillName);
        }
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
}