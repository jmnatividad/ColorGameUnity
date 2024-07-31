using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Result : MonoBehaviour
{
    //This script will handle the winning display and winning logic
    [Header("Reference Script")]
    [Header("Results")]
    private List<string> WinningHistory;

    public void AddWinningColors(string Result){
        WinningHistory.Add(Result);
    }
}
