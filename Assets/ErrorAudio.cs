using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip errorClip;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playErrorAudio(float vol)
    {
        source.PlayOneShot(errorClip, vol);
    }
}
