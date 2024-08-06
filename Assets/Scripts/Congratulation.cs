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
    public GameObject congratulationMiddleSection;

    public void congratsWinningMoney(bool state){
        if(betManagerVar.win > 0){
           winNumberText.text = $"{betManagerVar.win}";
            congratulationMiddleSection.SetActive(state);
            Debug.Log($"YOU WON: ${betManagerVar.win}"); 
        }
        
    }

    

}
