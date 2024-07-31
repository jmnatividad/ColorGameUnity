using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAudio : MonoBehaviour
{
    public AudioSource sourceMusic;
    public AudioSource sourceSFX;
    public AudioClip countdown_music;
    public AudioClip countdown_sfx;

    // Start is called before the first frame update
    void Start(){
        sourceMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countdownSounds(bool State){
        if(State == true){
            sourceMusic.clip = countdown_music;
            sourceMusic.Play();

            sourceSFX.clip = countdown_sfx;
            sourceSFX.loop = true;
            sourceSFX.Play();
        }else {
            sourceMusic.Stop();
            sourceSFX.Stop();
        }
    }
}