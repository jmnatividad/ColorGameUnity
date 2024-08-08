using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour
{
    public AudioSource sourceMusic;
    private bool increaseVolume, decreaseVolume;

    // Start is called before the first frame update
    void Start()
    {
        sourceMusic = GetComponent<AudioSource>();
        sourceMusic.volume = 0.1f;
        increaseVolume = false;
        decreaseVolume = false;
    }

    public void Update()
    {
        if (decreaseVolume == true)
        {
            sourceMusic.volume -= 0.05f * Time.deltaTime;
            if (sourceMusic.volume <= 0.05)
            {
                decreaseVolume = false;
                Debug.Log("Volumed lowered");
            }
        }

        if (increaseVolume == true)
        {
            sourceMusic.volume += 0.05f * Time.deltaTime;
            if (sourceMusic.volume >= 0.1)
            {
                increaseVolume = false;
                Debug.Log("Max volume");
            }
        }
    }

    public void adjustVolume(bool State)
    {
        decreaseVolume = State;
        increaseVolume = !State;
    }
}
