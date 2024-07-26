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
            float randomY = Random.Range(-1f, 1f);
            float randomX = Random.Range(0f, 10f);

            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                obj.transform.rotation  = Quaternion.Euler(randomX, randomY, obj.transform.rotation.z);
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
