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

    [Header("Winning History Collection")]
    public GameObject[] HistoryColorHolder;
    public GameObject[] HistoryNumHolder;

    [Header("Winning History list data")]
    public List<string[]> WinningHistory = new List<string[]>();

    public void AddHistoryWin(string TransactID ,string ColorResult1, string ColorResult2, string ColorResult3){
        
        WinningHistory.Add(new string[] { TransactID, ColorResult1, ColorResult2, ColorResult1 });
        // Debug.Log(WinningHistory[WinningHistory.Count-1]);

    }
    public void showColor(string color, string color2, string color3){
        int[] colornum = new int[3];
        string result ="";
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

        // result = string.Concat(strColors[colornum[1]], " , ", strColors[colornum[0]]," , ",strColors[colornum[2]]);
        // Debug.Log(strColors[colornum[1]]);
        // Debug.Log(strColors[colornum[0]]);
        // Debug.Log(strColors[colornum[2]]);
        // Debug.Log(result);
        
        //Add the winning colors in the history list
        AddHistoryWin("lol1" , strColors[colornum[1]], strColors[colornum[0]], strColors[colornum[2]]);
    }
    public void SetHisroryByTen(){
        Debug.Log("Winning History:");
        for (int i = 0; i < WinningHistory.Count; i++)
        {
            Debug.Log($"Entry {i + 1}:");
            foreach (string value in WinningHistory[i])
            {
                Debug.Log(value);
            }
        }
    }
    
}
