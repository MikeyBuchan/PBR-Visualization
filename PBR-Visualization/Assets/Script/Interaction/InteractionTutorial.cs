using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTutorial : InteractionBase
{
    
    public override void Interact()
    {
        Debug.Log("Interaction Tutorial");

        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(false);
        gameObject.GetComponent<MatirialMapsZoomBase>().interactCamera.SetActive(true);
        gameObject.GetComponent<MatirialMapsZoomBase>().allowRotation = true;
        GameObject.FindWithTag("MainCamera").SetActive(false);

        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().backToPlayerButton.SetActive(true);

    }
}
