using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] betColor;
    public BetManager betManagerVar;
    public ColorChoiceAudio colorChoiceAudioVar;
    public ErrorAudio errorAudioVar;
    public Dictionary<string, bool> currentColorSelected = new Dictionary<string, bool>{
        {"Yellow", false},
        {"White", false},
        {"Pink", false},
        {"Blue", false},
        {"Red", false},
        {"Black", false}
    };
    public Dictionary<string, bool> previousColorPick = new Dictionary<string, bool>();
    // private int currentIndex = -1; // Initialize with -1 to indicate no active button
    void Start()
    {
        for (int i = 0; i < betColor.Length; i++)
        {
            int index = i; // Capture index
            Button button = betColor[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(index));
        }
    }

    public void OnButtonClick(int index)
    {
        if (currentColorSelected[getColor(index)])
        {
            // Revert the clicked button to its default image
            betColor[index].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            currentColorSelected[getColor(index)] = false;
            colorChoiceAudioVar.playClickColor(false);
        }
        else
        {
            if (betManagerVar.bet < betManagerVar.balance)
            {
                betColor[index].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                currentColorSelected[getColor(index)] = true;
                colorChoiceAudioVar.playClickColor(true);
            }
        }
    }
    private string getColor(int index)
    {
        if (index == 0) return "Yellow";
        if (index == 1) return "White";
        if (index == 2) return "Pink";
        if (index == 3) return "Blue";
        if (index == 4) return "Red";
        if (index == 5) return "Black";
        return "";
    }
    public void maxButtonClick()
    {
        colorChoiceAudioVar.playClickColor(true);
        // Create a list of keys from the dictionary
        var keys = new List<string>(currentColorSelected.Keys);

        // Iterate over the list of keys and modify the dictionary
        foreach (var color in keys)
        {
            currentColorSelected[color] = true;
        }


        if (betManagerVar.bet <= betManagerVar.balance)
        {
            setColor();
        }
        else
        {
            foreach (var color in keys)
            {
                currentColorSelected[color] = false;
                errorAudioVar.playErrorAudio(0.5f);
            }
        }
    }
    // check if balance allows for quick pick
    public void quickPickClick()
    {
        colorChoiceAudioVar.playClickColor(true);
        // Debug.Log()
        // Create a list of keys from the dictionary
        var keys = new List<string>(currentColorSelected.Keys);

        // reset the tables;
        resetColor();
        // Shuffle the list of keys
        System.Random random = new System.Random();
        for (int i = keys.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            var temp = keys[i];
            keys[i] = keys[j];
            keys[j] = temp;
        }

        // Set at least three entries to true
        for (int i = 0; i < 3; i++)
        {
            currentColorSelected[keys[i]] = true;
        }
        if (betManagerVar.bet <= betManagerVar.balance)
        {
            setColor();
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                currentColorSelected[keys[i]] = false;
                errorAudioVar.playErrorAudio(1f);
            }
            betManagerVar.calculateBet();
        }

    }

    public void setColor()
    {
        int tempIndex = 0;
        foreach (var kvp in currentColorSelected)
        {
            if (kvp.Value)
            {
                betColor[tempIndex].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
            tempIndex++;
        }
    }
    public int getColorBets()
    {
        int count = 0;
        foreach (var kvp in currentColorSelected)
        {
            if (kvp.Value)
            {
                count++;
            }
        }
        return count;
    }
    public void setColor(Dictionary<string, bool> colors)
    {
        int tempIndex = 0;
        foreach (var kvp in colors)
        {
            if (kvp.Value)
            {
                betColor[tempIndex].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
            tempIndex++;
        }
    }
    public void resetColor()
    {

        var keys = new List<string>(currentColorSelected.Keys);

        // set all to false;
        foreach (var color in keys)
        {
            currentColorSelected[color] = false;
        }
        // foreach(var kvp in previousColorPick){
        //     Debug.Log($"{kvp.Key}: {kvp.Value}");
        // }
        foreach (GameObject GO in betColor)
        {
            GO.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
