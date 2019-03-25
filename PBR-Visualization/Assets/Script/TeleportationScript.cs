using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationScript : InteractionBase
{
    public GameObject popUp;
    public string sceneToLoad;

    private void Start()
    {
        popUp.SetActive(false);
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
    }

    public void NoSwitch()
    {
        Debug.Log("NO PLZ");
        popUp.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
