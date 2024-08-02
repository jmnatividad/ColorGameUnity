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
    private bool isRedoClicked = false;
    public Button quickPick;
    public Button changeChip;
    // private watchTableVariable
    
    public TextMeshProUGUI totalBetText;
    public TextMeshProUGUI winIndicatorText;
    public TextMeshProUGUI balanceText;
    //temporary
    public int balance;
    public int _bet;
    public int _win;
    
    public Dictionary<string, bool> tempDictionary=null;
    public int previousChipPick=-1;  
    public bool previousDoubleBet;
    // variable property
    // make it so that when a variable is accessed calculateBet will be triggered
    public int bet{
        get{
            calculateBet();
            return _bet;
        }
    }
    public int win{
        get{
            calculateWinnings();
            return _win;
        }
    }
    
    void Start()
    {

        StartCoroutine(WatchChipVariable());
        StartCoroutine(WatchTableVariable());
        maxPick.onClick.AddListener(() => colorChoiceVar.maxButtonClick());
        doubleBet.onClick.AddListener(() => chipChoiceVar.doubleBetClicked());
        quickPick.onClick.AddListener(() => colorChoiceVar.quickPickClick());
        undoPick.onClick.AddListener(() => undoPickClick());
        redoPick.onClick.AddListener(() => redoPickClick());
        balanceText.text = $"balance: ${balance}";
    }

    public void undoPickClick(){
        colorChoiceVar.resetColor();
        chipChoiceVar.resetChips();
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
        Dictionary<string, bool> previousDictionary = new Dictionary<string, bool>(colorChoiceVar.currentColorSelected);

        while (true)
        {
            // Check for changes in the dictionary
            foreach (var kvp in colorChoiceVar.currentColorSelected)
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
                if (!colorChoiceVar.currentColorSelected.ContainsKey(key))
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
        _bet=0;
        foreach(var kvp in colorChoiceVar.currentColorSelected){
            if(colorChoiceVar.currentColorSelected[kvp.Key]){
                _bet+=chipChoiceVar.currentChipSelected;
            }
        }
        // bet = totalBet;
        totalBetText.text = $"bet: ${_bet}";
    }
    public void calculateWinnings(){
        _win = 0;
        
        // winAmount = chipChoiceVar.currentChipSelected;
        string[] cubeStatesOutput = {
            resetObjectsVar.gameObjects[0].GetComponent<CubeState>().upperSide,
            resetObjectsVar.gameObjects[1].GetComponent<CubeState>().upperSide,
            resetObjectsVar.gameObjects[2].GetComponent<CubeState>().upperSide,
        };
        // List<string> tempList = new List<string> {};
        foreach(var kvp in colorChoiceVar.currentColorSelected){
            //check if user bets
            if(colorChoiceVar.currentColorSelected[kvp.Key]){
                foreach(string output in cubeStatesOutput){
                    if(output == kvp.Key){
                        _win+= (chipChoiceVar.currentChipSelected*2);
                    }
                }
            }
        }
        balance -= _bet;
        balance += _win;
        balanceText.text = $"balance: ${balance}";
        winIndicatorText.text = $"win: ${_win}";
        // get the last pick data
        captureLastData();
        
    }
    public void captureLastData(){
        //need to perform a deep copy
        colorChoiceVar.previousColorPick = new Dictionary<string, bool>(colorChoiceVar.currentColorSelected);
        chipChoiceVar.previousDoubleBetPick = chipChoiceVar.isDoubleBetClicked;
        chipChoiceVar.previousChipPick = chipChoiceVar.currentIndex;
    }
    public void redoPickClick(){
        if(chipChoiceVar.previousChipPick != -1 && colorChoiceVar.previousColorPick != null&& !isRedoClicked){
            isRedoClicked=true;
            colorChoiceVar.setColor(colorChoiceVar.previousColorPick);
            chipChoiceVar.isDoubleBetClicked = chipChoiceVar.previousDoubleBetPick;
            chipChoiceVar.OnButtonClick(chipChoiceVar.previousChipPick);
        }else{
            colorChoiceVar.resetColor();
            chipChoiceVar.resetChips();
            isRedoClicked=false;
        }
    }
    public void calculateBalance(){
        // balance
    }
}
