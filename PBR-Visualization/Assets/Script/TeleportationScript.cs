using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationScript : MonoBehaviour
{
    public GameObject popUp;
    public string sceneToLoad;

    bool freeMonePlayer;

    private void Start()
    {
        popUp.SetActive(false);
        freeMonePlayer = GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            Debug.Log("col");
            popUp.SetActive(true);
            freeMonePlayer = false;
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            Debug.Log("col II");
            popUp.SetActive(false);
            
        }
    }

    public void YesSwitch()
    {
        Debug.Log("YES PLZ");
        SceneManager.LoadScene(sceneToLoad);
    }

    public void NoSwitch()
    {
        Debug.Log("NO PLZ");
        popUp.SetActive(false);
        freeMonePlayer = false;
    }
}
