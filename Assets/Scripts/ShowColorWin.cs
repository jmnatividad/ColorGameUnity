using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColorWin : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] colorwinResult;
    public Sprite[] Colors;
    public string[] strColors = {"Pink", "Blue", "Red", "White","Yellow", "Black"};

    public List<string> WinningHistory = new List<string>();

    

    public void AddColorWin(string WinResult){
        if (WinResult.Length > 0)
        {
            string newString = WinResult.Substring(0, WinResult.Length - 2);
            WinResult = newString;
        }
        WinningHistory.Add(WinResult);
        Debug.Log(WinningHistory[WinningHistory.Count-1]);

    }
    public void showColor(string color, string color2, string color3){
        int[] colornum = new int[3];
        string result ="";
        for (int i = 0; i < strColors.Length; i++){
            if(color == strColors[i]){
                colornum[0] = i;
                result = string.Concat(result,strColors[i], " , ");
            }
            if(color2 == strColors[i]){
                colornum[1] = i;
                result = string.Concat(result, strColors[i], " , ");
            }
            if(color3 == strColors[i]){
                colornum[2] = i;
                result = string.Concat(result, strColors[i], " , ");
            }
        }
        colorwinResult[0].sprite = Colors[colornum[0]];
        colorwinResult[1].sprite = Colors[colornum[1]];
        colorwinResult[2].sprite = Colors[colornum[2]];
        //Add the winning colors in the history list 

        AddColorWin(result);
        
    }
    
}
