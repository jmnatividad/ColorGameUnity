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
    public int UpperSideTxt;
    public TextMeshProUGUI cubeStates;
    public CountdownSCR countdownVar;
    // public Countdown countdown_var;

    
    public GameObject middle_section;
    public GameObject color_choice;
    public GameObject background;

    public float[]  possibleAngles = { -360, -270, -180, -90, 0, 90, 180, 270, 360 };

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
        // countdown_var.startCountdowns();
        
    }

    // Update is called once per frame
    void Update()
    {

        cubeStates.text = gameObjects[0].GetComponent<CubeState>().upperSide + " " + gameObjects[1].GetComponent<CubeState>().upperSide + " " + gameObjects[2].GetComponent<CubeState>().upperSide;
    }

    public void randomRoll(){
        plank.SetActive(false);
        foreach (GameObject obj in gameObjects)
        {
            float randomY = Random.Range(-2f, 2f);
            float randomX = Random.Range(0f, 10f);
            if (obj != null)
            {         
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                int randomIndex = Random.Range(0, possibleAngles.Length);
                obj.transform.rotation  = Quaternion.Euler(obj.transform.rotation.x + possibleAngles[randomIndex] + randomX, obj.transform.rotation.y +possibleAngles[randomIndex] + randomY, obj.transform.rotation.z + possibleAngles[randomIndex]);
                // rb.mass += 10f;
            }
        }
        reset = false;
    }

    public void resetObject(){
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
                // obj.transform.rotation  = Quaternion.Euler(obj.transform.rotation.x + randomX, obj.transform.rotation.y + randomY, obj.transform.rotation.z);
                ctr++;
            }
        }
    }

    public void GamObjectActive(bool State_Active){
        middle_section.SetActive(State_Active);
        color_choice.SetActive(State_Active);
        background.SetActive(State_Active);
        // countdown.faceColor = new Color32(255, 255, 255, (State_Active ? 0 : 255));
        if(State_Active){
             countdown.faceColor = new Color32(255, 255, 255,255);

        }else countdown.faceColor = new Color32(255, 255, 255,0);
        // countdown.GetComponent<GameObject>().SetActive(State_Active);
    }
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
