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

    public int UpperSideTxt;
    public TextMeshProUGUI cubeStates;
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);


    public float[]  possibleAngles = { -360, -270, -180, -90, 0, 90, 180, 270, 360 };

    public void test(){
        Hello();
    }
    void Start()
    {

        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
               transform.Add(obj.transform.position);
            }
        }
        randomRoll();
        
    }

    // Update is called once per frame
    void Update()
    {
        // getState(gameObjects[1]);
        // Debug.Log(gameObjects[0].GetComponent<CubeState>().upperSide);
        cubeStates.text = gameObjects[0].GetComponent<CubeState>().upperSide + " " + gameObjects[1].GetComponent<CubeState>().upperSide + " " + gameObjects[2].GetComponent<CubeState>().upperSide;
    }

    public void randomRoll(){
        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
                int randomIndex = Random.Range(0, possibleAngles.Length);
                obj.transform.rotation  = Quaternion.Euler(obj.transform.rotation.x +possibleAngles[randomIndex], obj.transform.rotation.y +possibleAngles[randomIndex], obj.transform.rotation.z + possibleAngles[randomIndex]);
            }
        }
        reset = false;
    }

    public void resetObject(){
        int ctr = 0;
        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                obj.transform.position = transform[ctr];
                ctr++;
            }
        }
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
