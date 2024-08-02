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

    public ParticleSystem ConeParticleTop;
    public ParticleSystem ConeParticleBottom;

    // Start is called before the first frame update
    void Start()
    {
        resetVar.GamObjectActive(true);
        //Initialization of Particles to Stop (Placeholder)
    }

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
        
        while (seconds > 0)
        {
            if(seconds < 4){
                img_def_placeyourbet.sprite = img_red_placeyourbet;
                ConeParticleTop.Play();
                ConeParticleBottom.Play();
            }
            else    
                img_def_placeyourbet.sprite = img_green_placeyourbet;
                ConeParticleTop.Stop();
                ConeParticleBottom.Stop();  
                

            // Debug.Log("Countdown: " + seconds);
            resetVar.countdown.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
