using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Congratulation : MonoBehaviour
{
    // Start is called before the first frame update
    public BetManager betManagerVar;
    public TextMeshProUGUI winNumberText;

    public NeonEffect neonEffectVar;

    public Image CongratulationNeon;
    public GameObject congratulationMiddleSection;

    public void congratsWinningMoney(bool state){
        if(betManagerVar.win > 0){
            // winNumberText.text = $"{betManagerVar.win}";
            congratulationMiddleSection.SetActive(state);
            neonEffectVar.img = CongratulationNeon;
            StartCoroutine(neonEffectVar.FadeImage(true));
            StartCoroutine(countToTargetNum(betManagerVar.win));
            Debug.Log($"YOU WON: ${betManagerVar.win}"); 
        }
        
    }
    IEnumerator countToTargetNum(int targetNum){
        float time = 0f;
        int currentNumber = 0;

        while (time < 3.0f)
        {
            time += Time.deltaTime;
            // the countup for the targetnum
            currentNumber = Mathf.FloorToInt(Mathf.Lerp(0, targetNum, time / 3.0f));
            winNumberText.text = currentNumber.ToString();
            yield return null;
        }
        winNumberText.text = targetNum.ToString();

    }

    

}
