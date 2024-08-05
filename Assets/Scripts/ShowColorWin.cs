using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowColorWin : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] colorwinResult;
    public Sprite[] Colors;
    public string[] strColors = {"Pink", "Blue", "Red", "White","Yellow", "Black"};

    [Header("Winning History Collection")]
    public GameObject[] HistoryColorHolder;
    public TextMeshProUGUI[] HistoryNumHolder;

    [Header("Winning History list data")]
    private string TransactID = "";
    public List<string[]> WinningHistory = new List<string[]>();
    public void Start(){
        ResetHistory();
    }

    public void AddHistoryWin(string TransactID ,string ColorResult1, string ColorResult2, string ColorResult3){
        
        WinningHistory.Add(new string[] { TransactID, ColorResult1, ColorResult2, ColorResult3 });
        
        // Debug.Log(WinningHistory[WinningHistory.Count-1] + " " + WinningHistory.Count);

    }
    public void showColor(bool state ,string color, string color2, string color3){
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
        if(state){
            colorwinResult[0].sprite = Colors[colornum[0]];
            colorwinResult[1].sprite = Colors[colornum[1]];
            colorwinResult[2].sprite = Colors[colornum[2]];

            AddHistoryWin("A000001" , strColors[colornum[1]], strColors[colornum[0]], strColors[colornum[2]]);
        }
        
    }
    public void SetHisroryByTen()
    {
        ResetHistory();
        int HistoryHolderCtr = 0;
        for (int i = WinningHistory.Count-1; i < WinningHistory.Count; --i)
        {
            if(i == -1 || HistoryHolderCtr == 10){
                break;
            }else{
                Transform child0 = HistoryColorHolder[HistoryHolderCtr].transform.GetChild(0);
                Transform child1 = HistoryColorHolder[HistoryHolderCtr].transform.GetChild(1);
                Transform child2 = HistoryColorHolder[HistoryHolderCtr].transform.GetChild(2);

                Image targetImage1 = child0.GetComponent<Image>();
                Image targetImage2 = child1.GetComponent<Image>();
                Image targetImage3 = child2.GetComponent<Image>();
            
                string[] entry = WinningHistory[i];

                for (int j = 1; j < WinningHistory[i].Length; j++)
                {
                    Color CurrentColor;
                    switch (j)
                        {
                            case 1:
                                CurrentColor = targetImage1.color;
                                CurrentColor.a = 1f;
                                targetImage1.color = CurrentColor;
                                targetImage1.sprite = ColorAssignmentToImage(entry[j]);
                                 break;
                            case 2:
                                CurrentColor = targetImage2.color;
                                CurrentColor.a = 1f;
                                targetImage2.color = CurrentColor;
                                targetImage2.sprite = ColorAssignmentToImage(entry[j]);
                                 break;
                            case 3:
                                CurrentColor = targetImage3.color;
                                CurrentColor.a = 1f;
                                targetImage3.color = CurrentColor;
                                targetImage3.sprite = ColorAssignmentToImage(entry[j]);
                                 break;
                            default:
                                Debug.LogWarning("No Output");
                                break;
                        }
                }
            }

                
            HistoryHolderCtr++;
        }
    }
    public void ResetHistory(){
        foreach(GameObject hist in HistoryColorHolder){
            Transform child0 = hist.transform.GetChild(0);
            Transform child1 = hist.transform.GetChild(1);
            Transform child2 = hist.transform.GetChild(2);

            Image targetImage1 = child0.GetComponent<Image>();
            Image targetImage2 = child1.GetComponent<Image>();
            Image targetImage3 = child2.GetComponent<Image>();

            Color CurrentColor;
            CurrentColor = targetImage1.color;
            CurrentColor.a = 0;
            targetImage1.color = CurrentColor;
            targetImage1.sprite = null;
            //2nd image 
            CurrentColor = targetImage2.color;
            CurrentColor.a = 0;
            targetImage2.color = CurrentColor;
            targetImage2.sprite = null;
            //3rd image
            CurrentColor = targetImage3.color;
            CurrentColor.a = 0;
            targetImage3.color = CurrentColor;
            targetImage3.sprite = null;
        }
    }
    public Sprite ColorAssignmentToImage(string color)
    {
        switch (color)
        {
            case "Pink":
                return Colors[0];
            case "Blue":
                return Colors[1];
            case "Red":
                return Colors[2];
            case "White":
                return Colors[3];
            case "Yellow":
                return Colors[4];
            case "Black":
                return Colors[5];
            default:
                Debug.LogWarning("Unknown color: " + color);
                return null; // Or return a default sprite if preferred
        }
    }
    
}
