using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsUI : MonoBehaviour
{
    // Start is called before the first frame update
    private bool sound_on = true;
    public Sprite[] spr_sounds_OnOff;
    public Image img_sound;
    public void sound_on_off(){
        if(sound_on){
            img_sound.sprite = spr_sounds_OnOff[1];
            sound_on = false;
        }
        else{
            img_sound.sprite = spr_sounds_OnOff[0];
            sound_on = true;
        }

    }
}
