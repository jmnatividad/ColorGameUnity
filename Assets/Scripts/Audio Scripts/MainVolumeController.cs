using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    public void SetVolume(float sliderValue)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void MuteToggle(bool state)
    {
        if (state == false)
        {
            SetVolume(1);
        }
        else
        {
            SetVolume(0.0001f);
        }
    }
}
