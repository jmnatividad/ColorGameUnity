using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeonEffect : MonoBehaviour
{
    public Image targetImage;
    public float fadeDuration = 1f;
    public float threshold = 0.6f;

    public void FadeIn()
    {
        targetImage.CrossFadeAlpha(0.6f, fadeDuration, false);
        Debug.Log("Fading");
    }

    public void FadeOut()
    {
        targetImage.CrossFadeAlpha(1f, fadeDuration, false);
    }

    private void Update() {
        Color targetImageColor = targetImage.color;
        float alphaValue = targetImageColor.a;
        int count = 10;
    }
}
