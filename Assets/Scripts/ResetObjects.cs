using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> gameObjects;
    public List<Vector3> transform;
    public bool reset = false;
    public bool play = false;

    public float[]  possibleAngles = { -360, -270, -180, -90, 0, 90, 180, 270, 360 };
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

}
