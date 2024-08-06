using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{
    public string upperSide;
    public int value;
    public Vector3 state;
    public int tolerance = 45;
    public float forceAmount = 10f;

    public CubeSFX cubeSFX;

    public int getState()
    {
        int iValue = -1;
        Vector3 cube = this.transform.eulerAngles;

        cube = new Vector3(RoundToNearest(Mathf.RoundToInt(Mathf.Abs(cube.x))),
                            RoundToNearest(Mathf.RoundToInt(Mathf.Abs(cube.y))),
                            RoundToNearest(Mathf.RoundToInt(Mathf.Abs(cube.z))));
        state = cube;
        // Debug.Log(this.name);
        // Debug.Log(cube.x);
        // Debug.Log(cube.y);
        // Debug.Log(cube.z);
        if (cube.x == 180 && cube.y == 270 ||
            cube.x == 0 && cube.z == 90)
        {
            iValue = 1; //orange
        }
        else if (cube.x == 270)
        {
            iValue = 2; //blue
        }
        else if (cube.x == 180 && cube.z == 0 ||
            cube.x == 0 && cube.z == 180)
        {
            iValue = 3; // red
        }
        else if (cube.x == 180 && cube.z == 180 ||
            cube.x == 0 && cube.z == 0)
        {
            iValue = 4; //green
        }
        else if (cube.x == 90)
        {
            iValue = 5; // yellow
        }
        else if (cube.x == 0 && cube.z == 270 ||
            cube.x == 180 && cube.z == 90)
        {
            iValue = 6; // purple
        }

        upperSide = translateInt(iValue);
        value = iValue;
        return iValue;
    }
    public string translateInt(int x)
    {
        if (x == 1) return "Pink";
        if (x == 2) return "Blue";
        if (x == 3) return "Red";
        if (x == 4) return "White";
        if (x == 5) return "Yellow";
        if (x == 6) return "Black";
        return "";
    }
    float RoundToNearest(float value)
    {

        if (Mathf.Abs(value - 0) < tolerance)
        {
            return 0;
        }
        else if (Mathf.Abs(value - 90) < tolerance)
        {
            return 90;
        }
        else if (Mathf.Abs(value - 180) < tolerance)
        {
            return 180;
        }
        else if (Mathf.Abs(value - 270) < tolerance)
        {
            return 270;
        }
        else
        {
            return 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getState();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            if (other.relativeVelocity.magnitude > 1)
            {
                cubeSFX.playCubeHit();
            }
            else if (other.relativeVelocity.magnitude > 0.1 && other.relativeVelocity.magnitude <= 1)
            {
                cubeSFX.playCubeLastHit();
            }
        }
        if (other.gameObject.tag == "CubeBox")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (other.relativeVelocity.magnitude > 1)
            {
                rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
            }
        }
    }

}
