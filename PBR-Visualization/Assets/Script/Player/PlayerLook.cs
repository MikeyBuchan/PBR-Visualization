using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    Transform player;
    float rotX;
    float rotY;
    public float clampMaxY;
    public float clampMinY;
    bool magGaanRoteren = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(enumerator());
    }

    void Update()
    {
        if (gameObject.transform.parent.GetComponent<PlayerMove>().freeMove == true && magGaanRoteren == true)
        {
            rotX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
            player.transform.Rotate(Vector3.up * rotX);

            rotY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
            if (rotY >= clampMaxY)
                rotY += (Input.GetAxis("Mouse Y") <= 0) ? Input.GetAxis("Mouse Y") : 0;

            else if (rotY <= clampMinY)
                rotY += (Input.GetAxis("Mouse Y") >= 0) ? Input.GetAxis("Mouse Y") : 0;
            else
                rotY += Input.GetAxis("Mouse Y");
            float addValue = (rotY >= clampMaxY) ? 0 : (rotY <= clampMinY) ? 0 : -Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
            gameObject.transform.Rotate(new Vector3(addValue, 0, 0));
        }
        else
        {
            Debug.Log("FreeMove == false");
        }
    }

    IEnumerator enumerator()
    {
        yield return null;
        magGaanRoteren = true;
    }
}
