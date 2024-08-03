using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSCR : MonoBehaviour
{
    public ResetObjects resetVar;
    public BetManager betManagerVar;
    public ColorChoice colorChoiceVar;
    public ChipChoice chipChoiceVar;
    public Congratulation congratulationVar;

    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;

    public ParticleSystem ConeParticleTop;
    public ParticleSystem ConeParticleBottom;

    public int countDownCtr = 10;

    // Start is called before the first frame update
    void Start()
    {
        resetVar.GamObjectActive(true);
        //Initialization of Particles to Stop (Placeholder)
        ConeParticleTop.Stop();
        ConeParticleBottom.Stop();
    }

    public void startCountdown(){
        StartCoroutine(RepeatCoroutine());
    }

    IEnumerator RepeatCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(CountdownTest(countDownCtr)); // Wait for 10 seconds for placing bet
            resetVar.randomRoll();
            resetVar.GamObjectActive(false);
            chipChoiceVar.chipButtonsInteractable(false);
            Debug.Log("game wheel");
            // add another function for the wheel multiplier:
            yield return new WaitForSeconds(5f); // rolling cube
            resetVar.showResultColor(true);

            yield return new WaitForSeconds(5f); // show result
            resetVar.showResultColor(false);

            //show wheel
            
            yield return new WaitForSeconds(20f);
            betManagerVar.calculateWinnings();
            congratulationVar.congratsWinningMoney(true);

            yield return StartCoroutine(CountdownTest(15)); // Wait for another 20 seconds
            congratulationVar.congratsWinningMoney(false);

            yield return new WaitForSeconds(5f); // Wait for another 20 seconds

            
            // to do: get the previous pick
            resetVar.resetObject();
            resetVar.GamObjectActive(true);
            colorChoiceVar.resetColor();
            chipChoiceVar.resetChips();
            chipChoiceVar.chipButtonsInteractable(true);


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
                

            // Debug.Log("Countdown: " + seconds);
            resetVar.countdown.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
