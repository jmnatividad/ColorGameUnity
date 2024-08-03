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

    public void winning_number(){
        winNumberText.text = $"YOU WON: ${betManagerVar._win}";

        Debug.Log($"YOU WON: ${betManagerVar._win}");
    }
    

}
