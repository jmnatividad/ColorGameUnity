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
    private void displayFrequencies()
    {
        string temp="";
        foreach (var color in colorCounts.Keys)
        {
            double percentage = ((double)colorCounts[color] / totalPicks) * 100;
            colorCountsFrequency[color] = percentage;
            temp+= ($"{color} {colorCountsFrequency[color]:F2}%\n");
        }

        frequencies[0].text = $"{colorCountsFrequency["Black"]:F1}%";
        frequencies[1].text = $"{colorCountsFrequency["Red"]:F1}%";
        frequencies[2].text = $"{colorCountsFrequency["Blue"]:F1}%";
        frequencies[3].text = $"{colorCountsFrequency["White"]:F1}%";
        frequencies[4].text = $"{colorCountsFrequency["Pink"]:F1}%";
        frequencies[5].text = $"{colorCountsFrequency["Yellow"]:F1}%";
        // frequencies.text = temp;
    }
    public void getFrequencies(){
        totalPicks+=3;
        colorCounts[resetVar.gameObjects[0].GetComponent<CubeState>().upperSide]++;
        colorCounts[resetVar.gameObjects[1].GetComponent<CubeState>().upperSide]++;
        colorCounts[resetVar.gameObjects[2].GetComponent<CubeState>().upperSide]++;
        displayFrequencies();
    }
}
