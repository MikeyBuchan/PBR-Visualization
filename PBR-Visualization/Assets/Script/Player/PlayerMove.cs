using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 direction;
    public bool freeMove = true;
    public AudioSource source;
    public MaterialMapsZoomBase materialMapsZoomBase;
        
    void FixedUpdate()
    {
        if (freeMove == true && materialMapsZoomBase.zoomdIn == false)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                PLayerMovement();
            }
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                source.enabled = true;
            else
                source.enabled = false;
        }
    }

    void PLayerMovement()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
