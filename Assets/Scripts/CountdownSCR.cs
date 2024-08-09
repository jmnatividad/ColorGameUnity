using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownSCR : MonoBehaviour
{
    [Header("Reference Scripts")]
    public ResetObjects resetVar;
    public BetManager betManagerVar;
    public ColorChoice colorChoiceVar;
    public ChipChoice chipChoiceVar;
    public Congratulation congratulationVar;
    public WheelSpin wheelSpinVar;
    public CubeFrequencies cubeFrequenciesVar;
    public WheelAudio wheelAudioVar;
    public ChipChoiceAudio chipChoiceAudioVar;

    public CameraAction CamActions;

    [Header("UI Images")]
    public List<Sprite> CanvasSprite;
    public Image img_def_placeyourbet;
    public Sprite img_green_placeyourbet;
    public Sprite img_red_placeyourbet;

    public Image neon;
    public Sprite img_green_placeyourbet_neon;
    public Sprite img_red_placeyourbet_neon;

    

    [Header("Game Objects")]
    public List<GameObject> VfxGameObjects;
    public List<GameObject> CanvasImage;

    public ParticleSystem ConeParticleTop;
    public ParticleSystem ConeParticleBottom;

    [Header("UI Text")]
    public List<TextMeshProUGUI> TextHolders;
    public TextMeshProUGUI nextGameText;

    [Header("Variables in Scripts")]

    public int countDownCtr = 10;
    private int countNextGame = 60;

    private bool BonusSpin = true;

    // Start is called before the first frame update
    void Start()
    {
        resetVar.GamObjectActive(true);
        //Initialization of Particles to Stop (Placeholder)
        ConeParticleTop.Stop();
        ConeParticleBottom.Stop();
    }

    public void startCountdown()
    {
        StartCoroutine(RepeatCoroutine());
    }

    IEnumerator RepeatCoroutine()
    {

        while (true)
        {
            StartCoroutine(countDownNextGame(countNextGame));

            //"~~~~~~~~~~~~~~~~ 00 Seconds ~~~~~~~~~~~~~~~~~~~~~~~~"
            CamActions.CameraAngle("ColorGame"); //Camera to Color game table

            yield return StartCoroutine(CountdownTest(countDownCtr)); // Wait for 10 seconds for placing bet
            wheelSpinVar.RandomWheelRotation();

            resetVar.PlankBehavior("StartGame"); //responsible for starting the plank anim
            resetVar.GamObjectActive(false);
            chipChoiceVar.chipButtonsInteractable(false);

            yield return new WaitForSeconds(5f); // rolling cube 5f
            resetVar.showResultColor(true);
            cubeFrequenciesVar.getFrequencies();

            yield return new WaitForSeconds(5f); // show result 5f
            CamActions.CameraAngle("WheelSpin"); //Camera to Wheel Spin
            resetVar.showResultColor(false);

            yield return new WaitForSeconds(1f);
            UiWheelShow(false,true);//activate Wheel UI announcement
            yield return new WaitForSeconds(2f);
            UiWheelShow(false,false); //deactivate Wheel UI announcement
            //"~~~~~~~~~~~~~~~~ NORMAL WHEEL SPIN ~~~~~~~~~~~~~~~~~~~~~~~~"
            yield return new WaitForSeconds(2f);
            wheelSpinVar.IsSpinning = true;
            wheelAudioVar.playWheelSpin(true);

            yield return new WaitForSeconds(10); //NormalSpin
            wheelSpinVar.IsSpinning = false;
            wheelAudioVar.playWheelSpin(false);
            
            yield return new WaitForSeconds(1);
            //Display what winning
            
            //"~~~~~~~~~~~~~~~~ Bonus WHEEL SPIN ~~~~~~~~~~~~~~~~~~~~~~~~"
            //If bonus spin = true proceed to Bonus spin
            yield return new WaitForSeconds(2);
            if(BonusSpin){
                UiWheelShow(true,true);
            }
            yield return new WaitForSeconds(2); // wait 5 sec
            if(BonusSpin){
                UiWheelShow(true,false);
                wheelSpinVar.IsSpinning = true;
                wheelAudioVar.playWheelSpin(true);
            }

            
            yield return new WaitForSeconds(10); //Spinning bonus spin
            wheelSpinVar.IsSpinning = false;
            wheelAudioVar.playWheelSpin(false);
            //"~~~~~~~~~~~~~~~~ END WHEEL SPIN ~~~~~~~~~~~~~~~~~~~~~~~~"

            betManagerVar.calculateWinnings();

            congratulationVar.congratsWinningMoney(true);
            resetVar.PlankBehavior("ResetGame"); //responsible for reseting the plank anim
            
            yield return StartCoroutine(CountdownTest(5)); 
            yield return new WaitForSeconds(2f);
            congratulationVar.congratsWinningMoney(false);
            CamActions.CameraAngle("Default"); //Camera to Default

            yield return new WaitForSeconds(3f); // Wait for another 5 seconds
            chipChoiceAudioVar.playChipExit();
            CamActions.ResetState(); //reset the values

            // to do: get the previous pick
            resetVar.resetObject();
            resetVar.GamObjectActive(true);
            colorChoiceVar.resetColor();
            chipChoiceVar.resetChips();
            chipChoiceVar.chipButtonsInteractable(true);


        }
    }
    public void UiWheelShow(bool isBonus, bool status){
        CanvasImage[0].SetActive(status);
        Transform TextHolder = CanvasImage[0].transform.GetChild(0);
        TextMeshProUGUI textComponent = TextHolder.GetComponent<TextMeshProUGUI>();
        if(isBonus == false){
            textComponent.text = "WHEEL TIME";
        }else{
            textComponent.text = "BONUS TIME";
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
