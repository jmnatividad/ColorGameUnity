using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] betTables;
    public BetManager betManagerVar;
    public Dictionary<string, bool> currentTableSelected = new Dictionary<string, bool>{
        {"Yellow", false},
        {"White", false},
        {"Pink", false},
        {"Blue", false},
        {"Red", false},
        {"Black", false}
    };
    // private int currentIndex = -1; // Initialize with -1 to indicate no active button
    void Start()
    {
        for (int i = 0; i < betTables.Length; i++)
        {
            int index = i; // Capture index
            Button button = betTables[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        if (currentTableSelected[getColor(index)])
        {
            // Revert the clicked button to its default image
            betTables[index].GetComponent<Image>().color = new Color(1f,1f,1f,1f);
            currentTableSelected[getColor(index)] = false;
        }
        else
        {
            if(betManagerVar.bet<betManagerVar.balance){
                betTables[index].GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);
                currentTableSelected[getColor(index)] = true;
            }
        }        
    }
    private string getColor(int index){
        if(index==0) return "Yellow";
        if(index==1) return "White";
        if(index==2) return "Pink";
        if(index==3) return "Blue";
        if(index==4) return "Red";
        if(index==5) return "Black";
        return "";
    }
    public void maxButtonClick()
    {
        // Create a list of keys from the dictionary
        var keys = new List<string>(currentTableSelected.Keys);

        // Iterate over the list of keys and modify the dictionary
        foreach (var color in keys)
        {
            currentTableSelected[color] = true;
        }
        foreach(GameObject GO in betTables){
            GO.GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);
        }
    }
    public void quickPickClick()
    {
        // Create a list of keys from the dictionary
        var keys = new List<string>(currentTableSelected.Keys);
        // reset the tables;
        resetTable();
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
            currentTableSelected[keys[i]] = true;
        }

        setTable();
    }

    public void setTable(){
        int tempIndex=0;
        foreach(var kvp in currentTableSelected){
            if(kvp.Value){
                betTables[tempIndex].GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);
            }
            tempIndex++;
        }
    }
    public void resetTable(){
        var keys = new List<string>(currentTableSelected.Keys);
        // set all to false;
        foreach (var color in keys)
        {
            currentTableSelected[color] = false;
        }
        foreach(GameObject GO in betTables){
            GO.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
        }
    }

}
