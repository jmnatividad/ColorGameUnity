using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownSCR : MonoBehaviour
{
    [Header("Script Reference")]
    public ResetObjects resetVar;
    public BetManager betManagerVar;
    public ColorChoice colorChoiceVar;
    public ChipChoice chipChoiceVar;
    public Congratulation congratulationVar;
    public WheelSpin wheelSpinVar;
    public CubeFrequencies cubeFrequenciesVar;

    public CameraAction CamActions;

    public CameraAction CamActions;


    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;

    public Image neon;
    public Sprite img_green_placeyourbet_neon;
    public Sprite img_red_placeyourbet_neon;

    public NeonEffect neonScript;

    public ParticleSystem ConeParticleTop;
    public ParticleSystem ConeParticleBottom;

    public TextMeshProUGUI nextGameText;

    public int countDownCtr = 10;
    private int countNextGame = 50;

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
            CamActions.CameraAngle("ColorGame"); //Camera to Color game table

            CamActions.CameraAngle("ColorGame"); //Camera to Color game table
            
            yield return StartCoroutine(CountdownTest(countDownCtr)); // Wait for 10 seconds for placing bet
            wheelSpinVar.RandomWheelRotation();
            // resetVar.plank.SetActive(false);
            resetVar.PlankBehavior("StartGame");
            resetVar.GamObjectActive(false);
            chipChoiceVar.chipButtonsInteractable(false);
            // add another function for the wheel multiplier:
            yield return new WaitForSeconds(5f); // rolling cube 5f
            resetVar.showResultColor(true);
            cubeFrequenciesVar.getFrequencies();

            yield return new WaitForSeconds(5f); // show result 5f

            CamActions.CameraAngle("WheelSpin"); //Camera to Wheel Spin
            resetVar.showResultColor(false);

            yield return new WaitForSeconds(5f);
            //show wheel
            resetVar.PlankBehavior("ResetGame");

            wheelSpinVar.IsSpinning = true;

            yield return new WaitForSeconds(15f); //10f
            wheelSpinVar.IsSpinning = false;

            betManagerVar.calculateWinnings();
            
            congratulationVar.congratsWinningMoney(true);
            resetVar.PlankBehavior("ResetGame"); //responsible for reseting the plank anim

            yield return StartCoroutine(CountdownTest(5)); // Wait for another 15 seconds
            congratulationVar.congratsWinningMoney(false);
            CamActions.CameraAngle("Default"); //Camera to Default

            yield return new WaitForSeconds(1f); // Wait for another 5 seconds
            chipChoiceAudioVar.playChipExit();
            yield return new WaitForSeconds(4f); // Wait for another 5 seconds
            CamActions.ResetState(); //reset the values


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
            neonScript.StartCoroutine(neonScript.FadeImage(true));
            if (seconds < 4)
            {
                neon.sprite = img_red_placeyourbet_neon;
                img_def_placeyourbet.sprite = img_red_placeyourbet;
                ConeParticleTop.Play();
                ConeParticleBottom.Play();
            }
            else
            {
                img_def_placeyourbet.sprite = img_green_placeyourbet;
                neon.sprite = img_green_placeyourbet_neon;
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
        // nextGameText.gameObject.SetActive(false);
    }
}
