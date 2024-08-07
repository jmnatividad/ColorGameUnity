using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSFX : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> cubeHit;
    public List<AudioClip> cubeLastHit;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playCubeHit()
    {
        int ind = (int)Mathf.Floor(Random.Range(0, cubeHit.Count));
        source.PlayOneShot(cubeHit[ind], 4f);
    }

    public void playCubeLastHit()
    {
        int ind = (int)Mathf.Floor(Random.Range(0, cubeLastHit.Count));
        source.PlayOneShot(cubeLastHit[ind], 4f);
    }
}
