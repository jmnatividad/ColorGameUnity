using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeonEffect : MonoBehaviour
{
    public Image targetImage;
    public float fadeDuration = 1.0f;
    public float threshold = 0.4f;

    public void FadeIn()
    {
        targetImage.CrossFadeAlpha(threshold, fadeDuration, false);
        Debug.Log("Fading");
        FadeOut();
    }

    public void FadeOut()
    {
        targetImage.CrossFadeAlpha(1f, fadeDuration, false);
        Debug.Log("Unfading");
    }

    private void Update() {
        FadeIn();
       
    }
}
