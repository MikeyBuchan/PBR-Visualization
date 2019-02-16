using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTutorial : InteractionBase
{
    
    public override void Interact()
    {
        Debug.Log("Interaction Tutorial");

        gameObject.GetComponent<MaterialMapsZoomBase>().interactCamera.SetActive(true);
        gameObject.GetComponent<MaterialMapsZoomBase>().allowRotation = true;

        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backToPlayerButton.SetActive(true);
        base.Interact();
    }
    
}
