using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;
    Transform player;
    float rotX;
    float rotY;
    public float clampMaxY;
    public float clampMinY;
    public bool free = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (free == true)
        {
            rotX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            player.transform.Rotate(Vector3.up * rotX);
            rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            if (rotY >= clampMaxY)
                rotY += (Input.GetAxis("Mouse Y") <= 0) ? Input.GetAxis("Mouse Y") : 0;

            else if (rotY <= clampMinY)
                rotY += (Input.GetAxis("Mouse Y") >= 0) ? Input.GetAxis("Mouse Y") : 0;
            else
                rotY += Input.GetAxis("Mouse Y");
            float addValue = (rotY >= clampMaxY) ? 0 : (rotY <= clampMinY) ? 0 : -Input.GetAxis("Mouse Y");
            gameObject.transform.Rotate(new Vector3(addValue, 0, 0));
        }
    }
}
