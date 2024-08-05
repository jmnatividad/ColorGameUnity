using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    [Header("For Spinning")]
    public float initialSpinSpeed = 360f; // Initial speed in degrees per second
    public float spinDuration = 5f; // Duration of the spin in seconds

    private float currentSpinSpeed;
    public float elapsedTime = 0f;

    [Header("For Wheel Random Z")]
    // public float[]  RandomWheelZ = { -6f, -4f, -8f, 0f, 8f, 4f, 6f };

    
    [Header("Identify wheel is spinning")]
    public bool IsSpinning = true;
    void Start()
    {
        // Set the current spin speed to the initial speed at the start
        // currentSpinSpeed = initialSpinSpeed;
        RandomWheelRotation();
    }

    void Update()
    {
        SpinWheel();
    }
    public void RandomWheelRotation(){
        //randomize the rotation of the wheel every new game.
        currentSpinSpeed = initialSpinSpeed;
        float randomZ = Mathf.Round(Random.Range(0, 360f));
        this.transform.eulerAngles = new Vector3(Mathf.Round( 0), -210f, randomZ );
    }

    public void SpinWheel(){
        if(IsSpinning){
            if (elapsedTime < spinDuration)
            {
                // Calculate the amount of time passed since the last frame
                float deltaTime = Time.deltaTime;

                // Increment the elapsed time
                elapsedTime += deltaTime;

                // Calculate the remaining time
                float remainingTime = spinDuration - elapsedTime;

                // Ensure remaining time doesn't go below zero
                if (remainingTime < 0f)
                {
                    remainingTime = 0f;
                }

                // Calculate the new spin speed based on the remaining time
                currentSpinSpeed = initialSpinSpeed * (remainingTime / spinDuration);

                // Rotate the GameObject around the Z-axis
                transform.Rotate(0f, 0f, currentSpinSpeed * deltaTime);
            }
        }
    }
}
    

