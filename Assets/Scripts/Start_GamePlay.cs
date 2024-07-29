using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_GamePlay : MonoBehaviour
{
    public Countdown Countdown_var;
    public GameObject blocks;
    public GameObject middle_section;
    public GameObject color_choice;
    public GameObject background;

    public List<GameObject> gameObjects_cube;
    public List<Vector3> transform;

    public float countdown_for_start = 10f;

    void Start()
    {
        foreach (GameObject obj in gameObjects_cube)
        {
            if (obj != null)
            {
                transform.Add(obj.transform.position);
            }
        }
    }

    void Update()
    {
        if (Countdown_var.currentTime <= 0)
        {
            GameObjectsActive(false);
            Debug.Log("aaa");
            StartCoroutine(ResetObjects());
        }
    }
    IEnumerator ResetObjects()
    {
        
        yield return new WaitForSeconds(countdown_for_start);
        ResetObjectPositions();
    }
    
    public void ResetObjectPositions(){
        // int ctr = 0;
        // foreach (GameObject obj in gameObjects_cube)
        // {
        //     float randomY = Random.Range(-2f, 2f);
        //     float randomX = Random.Range(0f, 10f);
        //     if (obj != null)
        //     {
        //         Rigidbody rb = obj.GetComponent<Rigidbody>();
        //         rb.velocity = Vector3.zero;
        //         rb.angularVelocity = Vector3.zero;
        //         obj.transform.position = transform[ctr];
        //         // obj.transform.rotation  = Quaternion.Euler(obj.transform.rotation.x + randomX, obj.transform.rotation.y + randomY, obj.transform.rotation.z);
        //         ctr++;
        //     }
        // }

        // Countdown_var.RestartCountdown();
        GameObjectsActive(true);
    }
    public void GameObjectsActive(bool isActive)
    {
        blocks.SetActive(isActive);
        middle_section.SetActive(isActive);
        color_choice.SetActive(isActive);
        background.SetActive(isActive);
    }

}
