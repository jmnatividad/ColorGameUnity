using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownSCR : MonoBehaviour
{
    public ResetObjects resetVar;
    public BetManager betManagerVar;
    public ColorChoice colorChoiceVar;
    public ChipChoice chipChoiceVar;
    public Congratulation congratulationVar;
    public WheelSpin wheelSpinVar;
    public CubeFrequencies cubeFrequenciesVar;

    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;

    public Image neon;
    public Sprite img_green_placeyourbet_neon;
    public Sprite img_red_placeyourbet_neon;

    public ParticleSystem ConeParticleTop;
    public ParticleSystem ConeParticleBottom;

    public TextMeshProUGUI nextGameText;

    public int countDownCtr = 10;
    private int countNextGame = 60;

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
            StartCoroutine(countDownNextGame(countNextGame));
            
            yield return StartCoroutine(CountdownTest(countDownCtr)); // Wait for 10 seconds for placing bet
            resetVar.plank.SetActive(false);
            resetVar.GamObjectActive(false);
            chipChoiceVar.chipButtonsInteractable(false);
            // add another function for the wheel multiplier:
            yield return new WaitForSeconds(5f); // rolling cube 5f
            resetVar.showResultColor(true);
            cubeFrequenciesVar.getFrequencies();

            yield return new WaitForSeconds(5f); // show result 5f
            resetVar.showResultColor(false);
            //show wheel
            Debug.Log("game wheel");
            wheelSpinVar.IsSpinning = true;

            yield return new WaitForSeconds(20f); //20f
            wheelSpinVar.IsSpinning = false;

            betManagerVar.calculateWinnings();
            
            congratulationVar.congratsWinningMoney(true);

            yield return StartCoroutine(CountdownTest(15)); // Wait for another 15 seconds
            congratulationVar.congratsWinningMoney(false);

            yield return new WaitForSeconds(5f); // Wait for another 5 seconds

            
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
            if (seconds < 4)
        {
            neon.sprite = img_red_placeyourbet_neon;
            img_def_placeyourbet.sprite = img_red_placeyourbet;
            Debug.Log("Setting red sprites");
            ConeParticleTop.Play();
            ConeParticleBottom.Play();
        }
        else
        {
            img_def_placeyourbet.sprite = img_green_placeyourbet;
            neon.sprite = img_green_placeyourbet_neon;
            Debug.Log("Setting green sprites");
            ConeParticleTop.Stop();
            ConeParticleBottom.Stop();
        }

            // Debug.Log("Countdown: " + seconds);
            resetVar.countdown.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
    IEnumerator countDownNextGame(int nextGameSeconds)
    {
        // nextGameText.gameObject.SetActive(true);
        while (nextGameSeconds > 0)
        {
            nextGameText.text = $"Next Game: {nextGameSeconds}";
            yield return new WaitForSeconds(1f);
            nextGameSeconds--;
        }
        wheelSpinVar.RandomWheelRotation();
        // nextGameText.gameObject.SetActive(false);
    }
}
