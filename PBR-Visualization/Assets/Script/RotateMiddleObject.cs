using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMiddleObject : MonoBehaviour
{
    public MaterialMapsZoomBase mBase;
    public float Sspeed;
    public float lerpSpeed;
    Quaternion startRotation;

    void Update()
    {
        if (mBase.zoomdIn == true)
        {
            RotateObject();
        }

        if (mBase.zoomdIn == true)
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
        Debug.Log("for if");
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("TEGDTEGDTGETDGET");
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * Sspeed, Space.World);
        }
    }
}
