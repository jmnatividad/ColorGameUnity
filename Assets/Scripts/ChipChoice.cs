using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipChoice : MonoBehaviour
{
    public Image[] imageButtons;
    public Sprite[] activeImages;
    public Sprite[] defaultImages;
    public int currentIndex = -1;

    private int[] chipValues = { 5, 10, 50, 100, 500, 2500 };
    public int currentChipSelected = 0;
    public int previousChip;
    public BetManager betManagerVar;
    public bool isDoubleBetClicked = false;
    public int previousChipPick = -1;
    public bool previousDoubleBetPick;
    public ChipChoiceAudio chipChoiceAudioVar;
    public ErrorAudio errorAudioVar;

    // private bool isDoubleBetClicked = false;
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
    // known bug when valid click, and when u clicked 
    // an invalid two times, the valid clicked will be unclicked
    public void OnButtonClick(int index)
    {
        // if(chipValues[index] <= betManagerVar.balance){
        if (currentIndex == index)
        {
            imageButtons[index].sprite = defaultImages[index];
            currentIndex = -1;
            previousChip = currentChipSelected;
            currentChipSelected = 0;
            chipChoiceAudioVar.playChip();
        }
        else
        {

            int selectedValue = isDoubleBetClicked ? chipValues[index] * 2 : chipValues[index];
            // depending on the balance of the user, chips choice will be active when click
            // when the balance is more than the chip chosen. 
            if (selectedValue <= betManagerVar.balance)
            {
                if (currentIndex >= 0 && currentIndex < imageButtons.Length)
                    imageButtons[currentIndex].sprite = defaultImages[currentIndex];



                previousChip = currentChipSelected;

                imageButtons[index].sprite = activeImages[index];
                currentIndex = index;
                currentChipSelected = selectedValue;
                chipChoiceAudioVar.playChip();

                // temporary
                // to do: fix ugly code
                if (betManagerVar.bet > betManagerVar.balance)
                {
                    imageButtons[currentIndex].sprite = defaultImages[currentIndex];
                    currentChipSelected = 0;
                    currentIndex = -1;
                    betManagerVar.calculateBet();
                    errorAudioVar.playErrorAudio(3f);
                }
            }

            if (selectedValue > betManagerVar.balance)
            {
                errorAudioVar.playErrorAudio(3f);
            }

        }
    }
    // to do: create a coroutine that will check 
    // if the button is clicked so the currentChipSelected will be changed
    // to do: check if current index is equal to negative one
    public void doubleBetClicked()
    {
        if (!isDoubleBetClicked)
        {
            // betManagerVar.calculateBet();
            if (currentIndex == -1)
            {
                isDoubleBetClicked = true;
                chipChoiceAudioVar.playButtonClick(isDoubleBetClicked);
                betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                currentChipSelected = 0;
            }
            else if (chipValues[currentIndex] * 2 <= betManagerVar.balance && betManagerVar.bet < betManagerVar.balance)
            {
                // Debug.Log(chipValues[currentIndex]*2);
                // Debug.Log(betManagerVar.bet);
                isDoubleBetClicked = true;
                chipChoiceAudioVar.playButtonClick(isDoubleBetClicked);
                betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                currentChipSelected = chipValues[currentIndex] * 2;
            }
            else
            {
                errorAudioVar.playErrorAudio(3f);
            }

        }
        else
        {
            isDoubleBetClicked = false;
            chipChoiceAudioVar.playButtonClick(isDoubleBetClicked);
            betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            if (currentIndex == -1) currentChipSelected = 0;
            else currentChipSelected = chipValues[currentIndex] * 2;
        }
    }
    public void resetChips()
    {
        currentIndex = -1;
        for (int i = 0; i < imageButtons.Length; i++)
        {
            imageButtons[i].sprite = defaultImages[i];
        }
        isDoubleBetClicked = false;
        betManagerVar.doubleBet.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }
    public void chipButtonsInteractable(bool temp)
    {
        betManagerVar.maxPick.interactable = temp;
        betManagerVar.doubleBet.interactable = temp;
        betManagerVar.undoPick.interactable = temp;
        betManagerVar.redoPick.interactable = temp;
        betManagerVar.quickPick.interactable = temp;
        betManagerVar.changeChip.interactable = temp;
        foreach (var button in imageButtons)
        {
            button.GetComponent<Button>().interactable = temp;
        }
    }
}