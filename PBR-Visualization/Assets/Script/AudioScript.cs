using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("EnableTime")]
    public AudioSource source;
    public float enableTime;
    [Header("Offset")]
    public float audioOffsetMin;
    public float audioOffsetMax;
    public bool usesAudioOffset;
    public AudioClip clip;
    [Header("MovingAudio")]
    public bool rotatesAroundParent;
    public Vector3 rotationSpeed;

    public void Start()
    {
        if(usesAudioOffset)
            StartCoroutine(AudioOffset());
        StartCoroutine(StartAudio());
    }

    public void Update()
    {
        if (rotatesAroundParent)
            transform.parent.Rotate(rotationSpeed * Time.deltaTime);
    }

    public IEnumerator AudioOffset()
    {
        yield return new WaitForSeconds(clip.length + Random.Range(audioOffsetMin, audioOffsetMax));
        source.PlayOneShot(clip);
        StartCoroutine(AudioOffset());
    }

    public IEnumerator StartAudio()
    {
        yield return new WaitForSeconds(enableTime);
        source.enabled = true;
    }
}
