using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
public class ResetObjects : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> gameObjects;
    public List<Vector3> transform;
    public bool reset = false;
    public bool play = false;
    public GameObject plank;
    public Animator PlankAnimator;          
    public int UpperSideTxt;
    public TextMeshProUGUI cubeStates;
    public CountdownSCR countdownVar;
    public CountdownAudio countdownAudio;
    public ShowColorWin showcolorwinVar;
    // public Countdown countdown_var;

    
    public GameObject middleSectionPlaceyourbet;
    public GameObject colorChoice;
    public GameObject background;
    public GameObject showColor;

    public float[]  possibleAngles = { -360, -270, -180, -90, 0, 90, 180, 270, 360 };
    public float[]  RandomCubeAllignment = { -6f, -4f, -8f, 0f, 8f, 4f, 6f };
    public TextMeshProUGUI countdown;
    void Start()
    {

        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
               transform.Add(obj.transform.position);
            }
        }
        countdownVar.startCountdown();
        randomRoll();
        plank.SetActive(true);
        // countdown_var.startCountdowns();
        
    }

    // Update is called once per frame
    void Update()
    {
        // cubeStates.text = gameObjects[0].GetComponent<CubeState>().upperSide + " " + gameObjects[1].GetComponent<CubeState>().upperSide + " " + gameObjects[2].GetComponent<CubeState>().upperSide;
        // showcolorwinVar.showColor(gameObjects[0].GetComponent<CubeState>().upperSide,gameObjects[1].GetComponent<CubeState>().upperSide,gameObjects[2].GetComponent<CubeState>().upperSide);
    }

    public void randomRoll(){
        // plank.SetActive(false);
        foreach (GameObject obj in gameObjects)
        {
            float randomY = RandomCubeAllignment[Random.Range(0, RandomCubeAllignment.Length)];
            float randomX = RandomCubeAllignment[Random.Range(0, RandomCubeAllignment.Length)];
            if (obj != null)
            {         
                int randomIndex = Random.Range(0, possibleAngles.Length);
                // obj.transform.rotation  = Quaternion.Euler(obj.transform.rotation.x + possibleAngles[randomIndex] + randomX, obj.transform.rotation.y +possibleAngles[randomIndex] + randomY, obj.transform.rotation.z + possibleAngles[randomIndex]);
                obj.transform.eulerAngles = new Vector3(obj.transform.rotation.x + possibleAngles[randomIndex] + randomX, obj.transform.rotation.y +possibleAngles[randomIndex] + randomY, obj.transform.rotation.z + possibleAngles[randomIndex]);
            }
        }
        reset = false;
    }

    public void PlankBehavior(string Action){
        if(Action == "StartGame"){
            PlankAnimator.SetBool("PlayColorGame", true);
            PlankAnimator.SetBool("ResetColorGame", false);
        }else if (Action == "ResetGame"){
            PlankAnimator.SetBool("PlayColorGame", false);
            PlankAnimator.SetBool("ResetColorGame", true);
        }else{
            
        }
        
    }

    public void resetObject(){
        randomRoll();
        int ctr = 0;
        plank.SetActive(true);
        foreach (GameObject obj in gameObjects)
        {
            float randomY = Random.Range(-2f, 2f);
            float randomX = Random.Range(0f, 10f);
            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                obj.transform.position = transform[ctr];
                RoundOffAngles(obj);
                plank.SetActive(true);
                ctr++;
            }
        }
    }
    public void RoundOffAngles(GameObject cubes){
        //round off the angles so when the game resets the cube will look even 
        Vector3 cube = cubes.transform.eulerAngles;

        cube = new Vector3 (RoundToNearest(Mathf.RoundToInt (Mathf.Abs(cube.x))),
                            RoundToNearest(Mathf.RoundToInt (Mathf.Abs(cube.y))), 
                            RoundToNearest(Mathf.RoundToInt (Mathf.Abs(cube.z))));
        cubes.transform.eulerAngles = new Vector3(cube.x, cube.y, cube.z);
    }
    public float RoundToNearest(float value) {
        int tolerance = 45;
        //this is for the reset
        if (Mathf.Abs(value - 0) < tolerance) {
            return 0;
        } else if (Mathf.Abs(value - 90) < tolerance) {
            return 90;
        } else if (Mathf.Abs(value - 180) < tolerance) {
            return 180;
        } else if (Mathf.Abs(value - 270) < tolerance) {
            return 270;
        } else {
            return 0;
        }
    }

    public void GamObjectActive(bool State_Active){
        middleSectionPlaceyourbet.SetActive(State_Active);
        colorChoice.SetActive(State_Active);
        background.SetActive(State_Active);
        countdownAudio.countdownSounds(State_Active);
        // countdown.faceColor = new Color32(255, 255, 255, (State_Active ? 0 : 255));
        if(State_Active){
             countdown.faceColor = new Color32(255, 255, 255,255);

        }else countdown.faceColor = new Color32(255, 255, 255,0);
        // countdown.GetComponent<GameObject>().SetActive(State_Active);
    }

    public void showResultColor(bool state){
        showcolorwinVar.showColor(state ,gameObjects[0].GetComponent<CubeState>().upperSide,gameObjects[1].GetComponent<CubeState>().upperSide,gameObjects[2].GetComponent<CubeState>().upperSide);
        showColor.SetActive(state);
        if(state){
            showcolorwinVar.SetHisroryByTen();

        }
    }

    // IEnumerator WaitAndSetActive(bool state)
    // {
    //     // Debug.Log(state);
    //     if(state == true){


    //         yield return new WaitForSeconds(3f);
    //         showcolorwinVar.showColor(gameObjects[0].GetComponent<CubeState>().upperSide,gameObjects[1].GetComponent<CubeState>().upperSide,gameObjects[2].GetComponent<CubeState>().upperSide);
    //         showColor.SetActive(state);
    //         showcolorwinVar.SetHisroryByTen();
    //     } else showColor.SetActive(state);
    // }
    // public int getState (GameObject gameObject) {
    //     int iValue = -1;
    //     Vector3 cube = gameObject.transform.eulerAngles;

    //     cube = new Vector3 (Mathf.RoundToInt (cube.x), Mathf.RoundToInt (cube.y), Mathf.RoundToInt (cube.z));

    //     if (cube.x == 180 && cube.y == 270 ||
    //         cube.x == 0 && cube.z == 90) {
    //         iValue = 1; //orange
    //     } else if (cube.x == 270) {
    //         iValue = 2; //blue
    //     } else if (cube.x == 180 && cube.z == 0 ||
    //         cube.x == 0 && cube.z == 180) {
    //         iValue = 3; // red
    //     } else if (cube.x == 180 && cube.z == 180 ||
    //         cube.x == 0 && cube.z == 0) {
    //         iValue = 4; //green
    //     } else if (cube.x == 90) {
    //         iValue = 5; // yellow
    //     } else if (cube.x == 0 && cube.z == 270 ||
    //         cube.x == 180 && cube.z == 90) {
    //         iValue = 6; // purple
    //     }

    //     UpperSideTxt = iValue;
    //     return iValue;
    // }


}
