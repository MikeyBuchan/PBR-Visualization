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


    public override void Interact()
    {
        interactionCam.SetActive(true);
        base.Interact();
    }



}
