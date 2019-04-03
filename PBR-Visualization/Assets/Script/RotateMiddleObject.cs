using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMiddleObject : MonoBehaviour
{
    public MaterialMapsZoomBase baseClass;
    public float Sspeed;
    public float lerpSpeed;
    Quaternion startRotation;

    private void Start()
    {
        startRotation = gameObject.transform.rotation;
    }

    void Update()
    {
        if (baseClass.zoomdIn == true)
        {
            RotateObject();
        }
        else if (gameObject.transform.rotation != startRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * lerpSpeed);
        }
    }

    void RotateObject()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * Sspeed, Space.World);
        }
    }
}
