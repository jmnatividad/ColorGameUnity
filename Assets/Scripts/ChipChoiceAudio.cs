using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipChoiceAudio : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> chip;

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
}
