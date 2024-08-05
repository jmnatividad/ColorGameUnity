using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeonEffect : MonoBehaviour
{
    public Image i;
    public Sprite green;
    public Sprite red;
    private bool isGreen = true;

    // Update is called once per frame
    void Update()
    {
        if(isGreen)
        {
            i.sprite = green;
        }
        else
        {
            i.sprite = red;
        }
    }
}
