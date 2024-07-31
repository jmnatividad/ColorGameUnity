using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSCR : MonoBehaviour
{
    public ResetObjects resetVar;

    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;
    
    // Start is called before the first frame update
    
    void Start()
    {
<<<<<<< HEAD
        sourceMusic = GetComponent<AudioSource>();
    }

    // void playCountdownSound(){
    //     sourceMusic.clip = countdown_music;
    //     sourceMusic.Play();
    // }

    // void countdownSFX(){
    //     sourceSFX.PlayOneShot(countdown_sfx, 0.8f);
    // }
=======
        
    }
>>>>>>> 08c96ed (Added AudioManager GameObject + script)

    public void startCountdown(){
        StartCoroutine(RepeatCoroutine());
    }

    IEnumerator RepeatCoroutine()
    {
        while (true)
        {
            
            yield return StartCoroutine(CountdownTest(10)); // Wait for 10 seconds
            resetVar.randomRoll();
            
            resetVar.GamObjectActive(false);
            yield return StartCoroutine(CountdownTest(10)); // Wait for another 10 seconds
            resetVar.resetObject();
            resetVar.GamObjectActive(true);
            
        }
    }
    IEnumerator CountdownTest(int seconds)
    {
<<<<<<< HEAD
        // playCountdownSound();
        while (seconds > 0)
        {
            // countdownSFX(); //for sfx per sec 
=======
        //playCountdownSound();
        while (seconds > 0)
        {
            //countdownSFX(); //for sfx per sec 
>>>>>>> 08c96ed (Added AudioManager GameObject + script)
            if(seconds < 4 ){
                img_def_placeyourbet.sprite = img_red_placeyourbet;
            }
            else    
                img_def_placeyourbet.sprite = img_green_placeyourbet;

            // Debug.Log("Countdown: " + seconds);
            resetVar.countdown.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
