using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BetManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ChipChoice chipChoiceVar;
    public ColorChoice colorChoiceVar;
    public ResetObjects resetObjectsVar;
    public Button maxPick;
    public Button doubleBet;
    public Button undoPick;
    public Button redoPick;
    public Button quickPick;
    public Button changeChip;
    // private watchTableVariable
    
    public TextMeshProUGUI totalBetText;
    public TextMeshProUGUI winIndicatorText;
    public TextMeshProUGUI balanceText;
    //temporary
    public int balance;
    public int bet;
    public int win;
    void Start()
    {

        StartCoroutine(WatchChipVariable());
        StartCoroutine(WatchTableVariable());
        maxPick.onClick.AddListener(() => colorChoiceVar.maxButtonClick());
        doubleBet.onClick.AddListener(() => chipChoiceVar.doubleBetClicked());
        quickPick.onClick.AddListener(() => colorChoiceVar.quickPickClick());
        balanceText.text = $"balance: ${balance}";
    }

    IEnumerator WatchChipVariable()
    {
        // Store the initial value of the variable
        int previousValue = chipChoiceVar.currentChipSelected;

        while (true)
        {
            // Check if the variable's value has changed
            if (chipChoiceVar.currentChipSelected != previousValue)
            {
                // Log the change
                calculateBet();
                // Update the previous value
                previousValue = chipChoiceVar.currentChipSelected;
            }

            // Wait for the next frame
            yield return null;
        }
    }

    IEnumerator WatchTableVariable()
    {
        // Store the initial state of the dictionary
        Dictionary<string, bool> previousDictionary = new Dictionary<string, bool>(colorChoiceVar.currentTableSelected);

        while (true)
        {
            // Check for changes in the dictionary
            foreach (var kvp in colorChoiceVar.currentTableSelected)
            {
                if (!previousDictionary.ContainsKey(kvp.Key) || previousDictionary[kvp.Key] != kvp.Value)
                {
                    // Log the change
                    // Debug.Log($"Key '{kvp.Key}' changed from {previousDictionary.GetValueOrDefault(kvp.Key, false)} to {kvp.Value}");
                    calculateBet();
                    // Update the previous dictionary
                    previousDictionary[kvp.Key] = kvp.Value;
                }
            }

            // Remove keys that were in the previous dictionary but are no longer in the monitored dictionary
            foreach (var key in new List<string>(previousDictionary.Keys))
            {
                if (!colorChoiceVar.currentTableSelected.ContainsKey(key))
                {
                    // Remove the key from the previous dictionary
                    previousDictionary.Remove(key);
                }
            }
            // Wait for the next frame
            yield return null;
        }
    }
    // temporary 
    public void calculateBet(){
        bet=0;
        foreach(var kvp in colorChoiceVar.currentTableSelected){
            if(colorChoiceVar.currentTableSelected[kvp.Key]){
                bet+=chipChoiceVar.currentChipSelected;
            }
        }
        // bet = totalBet;
        totalBetText.text = $"bet: ${bet}";
    }
    public void calculateWinnings(){
        int winAmount = 0;
        
        // winAmount = chipChoiceVar.currentChipSelected;
        string[] cubeStatesOutput = {
            resetObjectsVar.gameObjects[0].GetComponent<CubeState>().upperSide,
            resetObjectsVar.gameObjects[1].GetComponent<CubeState>().upperSide,
            resetObjectsVar.gameObjects[2].GetComponent<CubeState>().upperSide,
        };
        // List<string> tempList = new List<string> {};
        foreach(var kvp in colorChoiceVar.currentTableSelected){
            //check if user bets
            if(colorChoiceVar.currentTableSelected[kvp.Key]){
                // tempList.Add(kvp.Key);
                foreach(string output in cubeStatesOutput){
                    if(output == kvp.Key){
                        winAmount+= (chipChoiceVar.currentChipSelected*2);
                    }
                }
            }
        }
        balance = balance-bet;
        balanceText.text = $"balance: ${balance}";
        winIndicatorText.text = $"win: ${winAmount}";
    }
    public void calculateBalance(){
        // balance
    }
}
