using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationScript : InteractionBase
{
    public GameObject popUp;
    public string sceneToLoad;
    UIManager uimanager;

    private void Start()
    {
        popUp.SetActive(false);
        uimanager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            TeleportInteract();
        }
    }

    public override void TeleportInteract()
    {
        popUp.SetActive(true);
        base.TeleportInteract();
    }

    public void YesSwitch()
    {
        Debug.Log("YES PLZ");
        SceneManager.LoadScene(sceneToLoad);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        uimanager.crosHair.SetActive(false);
    }

    public void NoSwitch()
    {
        Debug.Log("NO PLZ");
        popUp.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        uimanager.crosHair.SetActive(true);
    }
}
