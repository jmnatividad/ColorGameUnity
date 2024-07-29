using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSCR : MonoBehaviour
{
    public ResetObjects resetVar;
    // Start is called before the first frame update
    void Start()
    {
        
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
            
            yield return StartCoroutine(CountdownTest(10)); // Wait for another 10 seconds
            resetVar.resetObject();
            
        }
    }
    IEnumerator CountdownTest(int seconds)
    {
        while (seconds > 0)
        {
            Debug.Log("Countdown: " + seconds);
            resetVar.countdown.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
