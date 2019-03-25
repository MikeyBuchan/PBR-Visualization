using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("base interact");
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
        GameObject.FindWithTag("UiManager").GetComponent<UIManager>().interactDisplay.SetActive(false);
        GameObject.FindWithTag("MainCamera").SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public virtual void TeleportInteract()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
