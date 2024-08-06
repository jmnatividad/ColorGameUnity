using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void CameraAngle(string state){

        switch (state)
        {
            case "StartGame":
                animator.SetBool("StartGame", true);
                break;
            case "ColorGame":
                animator.SetBool("ColorGame", true);
                animator.SetBool("WheelSpin", false);
                animator.SetBool("Default", false);
                animator.SetBool("StartGame", false);
                break;
            case "WheelSpin":
                animator.SetBool("WheelSpin", true);
                animator.SetBool("ColorGame", false);
                animator.SetBool("Default", false);
                break;
            case "Default":
                animator.SetBool("Default", true);
                animator.SetBool("ColorGame", false);
                animator.SetBool("WheelSpin", false);
                break;
            default:
                // Debug.LogError("Unknown state");
                break;
        }
    }
    public void ResetState(){
        animator.SetBool("WheelSpin", false);
        animator.SetBool("ColorGame", false);
        animator.SetBool("Default", false);
    }
}
