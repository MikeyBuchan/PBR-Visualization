using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTutorial : InteractionBase
{
    public bool interBool = false;

    public override void Interact()
    {
        Debug.Log("Interaction Tutorial");

        gameObject.GetComponent<MaterialMapsZoomBase>().interactCamera.SetActive(true);
        gameObject.GetComponent<MaterialMapsZoomBase>().allowRotation = true;
        gameObject.GetComponent<Animator>().SetTrigger("Toggle");
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backToPlayerButton.SetActive(true);
        interBool = true;
        base.Interact();
    }
    
}
