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
    

    public void showColor(string color, string color2, string color3){
        int[] colornum = new int[3];
        int n;
        for (int i = 0; i < strColors.Length; i++){
            if(color == strColors[i]){
                colornum[0] = i;
            }
            if(color2 == strColors[i]){
                colornum[1] = i;
            }
            if(color3 == strColors[i]){
                colornum[2] = i;
            }
        }
        colorwinResult[0].sprite = Colors[colornum[0]];
        colorwinResult[1].sprite = Colors[colornum[1]];
        colorwinResult[2].sprite = Colors[colornum[2]];
    }
}
