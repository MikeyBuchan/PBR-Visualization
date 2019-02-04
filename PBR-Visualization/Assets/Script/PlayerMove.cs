using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 direction;
    float horizontal;
    float vertical;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PLayerMovement();
        }
    }

    void PLayerMovement()
    {
        direction.x = -Input.GetAxis("Horizontal");
        direction.z = -Input.GetAxis("Vertical");
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
