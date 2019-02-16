using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMaterialChanger : InteractionBase
{
    public GameObject interactCamera;
    public bool mayMatChange = false;

    private void Start()
    {
        interactCamera.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log("MChager");
        interactCamera.SetActive(true);
        mayMatChange = true;
        base.Interact();
    }

}
