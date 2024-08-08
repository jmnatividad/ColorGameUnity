using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class WheelSpin : MonoBehaviour
{

    [Header("For Multiplier")]
    public Transform WheelPointer;
    public float rayDistance = 150f;
    
    [Header("For Spinning")]
    public float initialSpinSpeed = 360f; // Initial speed in degrees per second
    public float spinDuration = 5f; // Duration of the spin in seconds

    private float currentSpinSpeed;
    public float elapsedTime = 0f;
    

    [Header("For Wheel Random Z")]
    public float WheelX = 0f;
    public float WheelY = 0f;
    public float WheelZ = 0f;
    // public float[]  RandomWheelZ = { -6f, -4f, -8f, 0f, 8f, 4f, 6f };

    
    [Header("Identify wheel is spinning")]
    public bool IsSpinning = false;
    void Start()
    {
        RandomWheelRotation();
    }

    void Update()
    {
        // Debug.Log(this.transform.eulerAngles);
        SpinWheel();
        MultiplierPointer();
    }
    public void RandomWheelRotation(){
        //randomize the rotation of the wheel every new game.
        currentSpinSpeed = initialSpinSpeed;
        float randomY = Mathf.Round(Random.Range(0, 360f));
        randomY = Mathf.Clamp(randomY, 0f, 360f);
        transform.Rotate(0f, randomY, 0f );
        // this.transform.eulerAngles = new Vector3(randomZ, 220f, 90f );
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
                transform.Rotate(0f, currentSpinSpeed * deltaTime, 0f );
            }
        }else{
            elapsedTime = 0f;
        }
    }
    public void MultiplierPointer(){
        // Define the ray origin and direction
        Vector3 rayOrigin = WheelPointer.position;
        Vector3 rayDirection = WheelPointer.forward;

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
        {
            // Debug.Log("Hit object: " + hit.collider.name);

            // Draw the ray in red if it hits an object
            Debug.DrawRay(rayOrigin, rayDirection * hit.distance, Color.green);
        }
        else
        {
            // Draw the ray in green if it doesn't hit anything
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);
        }
    }
}
    

