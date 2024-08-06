using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeFrequencies : MonoBehaviour
{
    public int totalPicks=0;
    public ResetObjects resetVar;
    public TextMeshProUGUI[] frequencies;
    // 0 black, 1 red, 2 blue, 3 white, 4 pink, 5 yellow
    // Start is called before the first frame update
    // private static List<List<string>> dataStates;
    public Dictionary<string, int> colorCounts = new Dictionary<string, int>
    {
        { "Pink", 0 },
        { "Blue", 0 },
        { "Red", 0 },
        { "White", 0 },
        { "Yellow", 0 },
        { "Black", 0 }
    };

    public Dictionary<string, double> colorCountsFrequency = new Dictionary<string, double>
    {
        { "Pink", 0f },
        { "Blue", 0f },
        { "Red", 0f },
        { "White", 0f },
        { "Yellow", 0f },
        { "Black", 0f }
    };
    private void Start() {
        resetFrequencies();
    }
    private bool isInt(double var){
        return (var%1)==0;
    }
    private string getColor(string str){
        return $"{(isInt(colorCountsFrequency[str]) ? colorCountsFrequency[str].ToString("F0") : colorCountsFrequency[str].ToString("F1"))}%";
    }
    private void displayFrequencies()
    {
        string temp="";
        foreach (var color in colorCounts.Keys)
        {
            double percentage = ((double)colorCounts[color] / totalPicks) * 100;
            colorCountsFrequency[color] = percentage;
            temp+= ($"{color} {colorCountsFrequency[color]:F2}%\n");
        }

        string[] tempColor = {"Black", "Red", "Blue", "White", "Pink", "Yellow"};
        for(int i=0;i<tempColor.Length;i++){
            frequencies[i].text = getColor(tempColor[i]);
        }
    }
    public void getFrequencies(){
        totalPicks+=3;
        foreach(var go in resetVar.gameObjects){
            colorCounts[go.GetComponent<CubeState>().upperSide]++;
        }
        displayFrequencies();
    }
    public void resetFrequencies(){
        foreach(var temp in frequencies){
            temp.text = $"0%";
        }
    }
}
