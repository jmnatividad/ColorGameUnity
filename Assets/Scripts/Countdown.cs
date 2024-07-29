using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TextMeshProUGUI  countdown_text;
    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;

    public float countdownTime = 10f;
    public int currentTime;

    public ResetObjects resetVar;
    
    public void startCountdowns(){
        
        countdown_text.text = countdownTime.ToString();
        img_def_placeyourbet.sprite = img_green_placeyourbet;
        StartCoroutine(RepeatCoroutines());
    }
    
    IEnumerator RepeatCoroutines()
    {
        while (true)
        {
            
            yield return StartCoroutine(Countdown_timer(10)); // Wait for 10 seconds
            resetVar.randomRoll();
            
            yield return StartCoroutine(Countdown_timer(10)); // Wait for another 10 seconds
            resetVar.resetObject();
            
        }
    }

    // public void RestartCountdown()
    // {
    //     // StopAllCoroutines();
        
    //     // currentTime = countdownTime;
    //     // StartCoroutine(Countdown_timer());
    // }

    IEnumerator Countdown_timer(int currentTime)
    {
        while(currentTime > 0){
            
            // currentTime -= Time.deltaTime;
            if(currentTime < 4 ){
                img_def_placeyourbet.sprite = img_red_placeyourbet;
            }
            else    
                img_def_placeyourbet.sprite = img_green_placeyourbet;

            countdown_text.text = Mathf.Ceil(currentTime).ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
    }
}
