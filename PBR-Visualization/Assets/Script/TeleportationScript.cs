using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationScript : MonoBehaviour
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
            popUp.SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = false;
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
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().freeMove = true;
    }
}
