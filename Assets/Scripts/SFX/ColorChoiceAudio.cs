using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoiceAudio : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> colorClick;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playClickColor(bool State)
    {
        if (State == true)
        {
            source.PlayOneShot(colorClick[0], 4f); //clicked
        }
        else
        {
            source.PlayOneShot(colorClick[1], 2f); //unclicked
        }
    }
}
