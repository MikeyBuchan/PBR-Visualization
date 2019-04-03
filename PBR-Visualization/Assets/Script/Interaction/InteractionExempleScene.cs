using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExempleScene : InteractionBase
{
    public GameObject interactionCam;


    private void Start()
    {
        interactionCam.SetActive(false);
    }

    public void Update()
    {
        Interact();
    }

    public override void Interact()
    {
        Debug.Log("TEst instraj");
        interactionCam.SetActive(true);
        base.Interact();
    }
}
