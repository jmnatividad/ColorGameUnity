using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipChoice : MonoBehaviour
{
    public Image[] imageButtons; // Array to hold references to the Image buttons
    public Sprite[] activeImages; // Array to hold the images for the active state of the buttons

    public Sprite[] defaultImages; // Array to hold the default images of the buttons
    private int currentIndex = -1; // Initialize with -1 to indicate no active button
    
    private int[] chipValues = { 5, 10, 50, 100, 500, 2500 };
    public int currentChipSelected=0;
    public int previousChip;
    public BetManager betManagerVar;
    private bool isDoubleBetClicked = false;
    private void Start()
    {

        for (int i = 0; i < imageButtons.Length; i++)
        {
            int index = i; // Capture index
            Button button = imageButtons[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(index));
        }
    }
    // to do 
    // 1: if a user clicked a chip, check for balance
    // 2: if a user has clicked a table with insufficient funds, stop
    // 3: if a user has clicked the double bet button, check for balance
    private void OnButtonClick(int index)
    {
        // if(chipValues[index] <= betManagerVar.balance){
        if (currentIndex == index)
        {
            // Revert the clicked button to its default image
            imageButtons[index].sprite = defaultImages[index];
            currentIndex = -1; // No active button
            previousChip = currentChipSelected;
            currentChipSelected = 0;
        }
        else
        {
            int selectedValue = isDoubleBetClicked ? chipValues[index] * 2 : chipValues[index];
            
            if(selectedValue <= betManagerVar.balance || selectedValue <= betManagerVar.bet){
                // Revert the previously active button
                if (currentIndex >= 0 && currentIndex < imageButtons.Length)
                    imageButtons[currentIndex].sprite = defaultImages[currentIndex];

                previousChip = currentChipSelected;

                // Set the new active button
                imageButtons[index].sprite = activeImages[index];
                currentIndex = index; // Update active index
                currentChipSelected = selectedValue;
                // if(isDoubleBetClicked){
                //     currentChipSelected = chipValues[currentIndex]*2;
                // }else currentChipSelected = chipValues[currentIndex];

                //temporary
                //to do: ugly code
                betManagerVar.calculateBet();
                Debug.Log(betManagerVar.bet);
                Debug.Log(selectedValue);
                if(betManagerVar.bet>betManagerVar.balance){
                    imageButtons[currentIndex].sprite = defaultImages[currentIndex];
                    currentChipSelected = 0;
                    betManagerVar.calculateBet();
                }
                
            }
            
        }
    }
    // to do: create a coroutine that will check 
    // if the button is clicked so the currentChipSelected will be changed
    // to do: check if current index is equal to negative one
    public void doubleBetClicked(){
        if(!isDoubleBetClicked){
            if(currentIndex==-1){
                isDoubleBetClicked = true;
                betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);
                currentChipSelected = 0;
            }else if(chipValues[currentIndex]*2<=betManagerVar.balance){
                isDoubleBetClicked = true;
                betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);
                currentChipSelected = chipValues[currentIndex]*2;
            }
            
        }else{
            isDoubleBetClicked = false;
            betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
            if(currentIndex==-1) currentChipSelected = 0;
            else currentChipSelected = chipValues[currentIndex]*2;
        }
    }
    public void resetChips(){
        currentIndex = -1;
        for(int i=0;i<imageButtons.Length ; i++){
            imageButtons[i].sprite = defaultImages[i];
        }
        isDoubleBetClicked = false;
        betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
    }
    public void chipButtonsInteractable(bool temp){
        betManagerVar.maxPick.interactable = temp;
        betManagerVar.doubleBet.interactable = temp;
        betManagerVar.undoPick.interactable = temp;
        betManagerVar.redoPick.interactable = temp;
        betManagerVar.quickPick.interactable = temp;
        betManagerVar.changeChip.interactable = temp;
        foreach(var button in imageButtons){
            button.GetComponent<Button>().interactable = temp;
        }
    }
}