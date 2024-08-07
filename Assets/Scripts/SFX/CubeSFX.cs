using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSFX : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> cubeHit;

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
}
