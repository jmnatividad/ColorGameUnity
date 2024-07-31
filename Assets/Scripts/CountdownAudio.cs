using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAudio : MonoBehaviour
{
    public AudioSource sourceMusic;
    public AudioSource sourceSFX;
    public AudioClip countdown_music;
    public AudioClip countdown_sfx;
    //private CountdownSCR countdownSCR;

    // Start is called before the first frame update
    void Start()
    {
        sourceMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playCountdownSound(){
        sourceMusic.clip = countdown_music;
        sourceMusic.Play();
    }

    void countdownSFX(){
        sourceSFX.PlayOneShot(countdown_sfx, 0.8f);
    }
}
