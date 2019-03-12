using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 direction;
    public bool freeMove = true;
    public AudioSource source;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (freeMove == true)
            {
                PLayerMovement();
            }
        }
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            source.enabled = true;
        else if (Input.GetButtonUp("Horizontal") && !Input.GetButton("Vertical") || Input.GetButtonUp("Vertical") && !Input.GetButton("Horizontal"))
            source.enabled = false;
    }

    void PLayerMovement()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
