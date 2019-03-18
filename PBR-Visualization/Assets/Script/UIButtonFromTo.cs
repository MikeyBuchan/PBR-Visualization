using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFromTo : MonoBehaviour
{
    public GameObject[] from;
    public GameObject[] to;
    public float rotationSpeed;
    AudioSource soundPlaysource;
    public string audioSourceTag;

    public void Start()
    {
        if (audioSourceTag != "")
            soundPlaysource = GameObject.FindWithTag(audioSourceTag).GetComponent<AudioSource>();
    }

    public void PlayUISound(AudioClip audio)
    {
        soundPlaysource.PlayOneShot(audio, 1);
    }

    public void OnButtonPress()
    {
        foreach (GameObject obj in from)
            obj.SetActive(false);
        foreach (GameObject obj in to)
            obj.SetActive(true);
    }

    public void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
