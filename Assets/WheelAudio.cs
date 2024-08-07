using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip wheelspin;
    float vol = 2f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playWheelSpin(bool State)
    {
        if (State == true)
        {
            source.PlayOneShot(wheelspin, 4f);
        }
        // source.clip = wheelspin;
        // source.volume = vol;
        // source.Play();
    }
}
