using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 direction;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (gameObject.GetComponentInChildren<PlayerLook>().freeMove == true)
            {
                PLayerMovement();
            }
        }
    }

    void PLayerMovement()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
