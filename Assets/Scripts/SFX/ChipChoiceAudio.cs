using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipChoiceAudio : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> chip;
    public List<AudioClip> buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playChip()
    {
        int ind = (int)Mathf.Floor(Random.Range(0, chip.Count));
        source.PlayOneShot(chip[ind], 2f);
    }

    public void playButtonClick(bool State)
    {
        if (State == true)
        {
            source.PlayOneShot(buttonClick[0], 2f); //clicked
        }
        else
        {
            source.PlayOneShot(buttonClick[1], 2f); //unclicked
        }
    }
}
