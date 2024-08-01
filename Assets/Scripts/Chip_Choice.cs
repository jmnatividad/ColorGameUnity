using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip_Choice : MonoBehaviour
{
    public Image[] imageButtons; // Array to hold references to the Image buttons
    public Sprite[] activeImages; // Array to hold the images for the active state of the buttons

    public Sprite[] defaultImages; // Array to hold the default images of the buttons
    private int currentIndex = -1; // Initialize with -1 to indicate no active button

    private int[] debugValues = { 5, 10, 50, 100, 500, 2500 };

    public ChipChoiceAudio chipChoiceAudio;

    private void Start()
    {

        for (int i = 0; i < imageButtons.Length; i++)
        {
            int index = i; // Capture index
            Button button = imageButtons[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        // Check if the clicked button is already active
        Debug.Log("curent:" + index);
        Debug.Log("curentind:" + currentIndex);

        if (currentIndex == index)
        {
            // Revert the clicked button to its default image
            imageButtons[index].sprite = defaultImages[index];
            currentIndex = -1; // No active button
            chipChoiceAudio.playChip();
        }
        else
        {

            //  Debug.Log(debugValues[index]);
            // Revert the previously active button
            if (currentIndex >= 0 && currentIndex < imageButtons.Length)
                imageButtons[currentIndex].sprite = defaultImages[currentIndex];

            // Set the new active button
            imageButtons[index].sprite = activeImages[index];
            currentIndex = index; // Update active index
            chipChoiceAudio.playChip();
        }
    }
}