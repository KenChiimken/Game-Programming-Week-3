using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RotationExample : MonoBehaviour
{
    public Quaternion currentRotation;
    float x, y, z;
    public Vector3 currentEulerAngles;
    public float rotSpeed;
    public Transform targetA, targetB;
    float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler (90, 90, 90);
        //transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        //RotationInputs();
        //QuaternionRotateTowards();
        //QuaternionSlerp();
        LookRotation();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;
        //use the Euler Angles to show the euler angles of the transform rotation
        GUI.Label(new Rect(10, 0, 0, 0),
            "Rotating on X" + x + "Y" + y + "Z" + z, style);
        //Outputs the Quaternion.euler angle values
        GUI.Label(new Rect(10, 25, 0, 0),
            "Current Euler angles" + currentEulerAngles, style);
        GUI.Label(new Rect(10, 50, 0, 0),
            "Game Object World Euler Angle" + transform.eulerAngles, style);
    }

    private void RotationInputs()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            x = 1 - x;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            y = 1 - y;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            z = 1 - z;
        }

            //Modify the vector 3 based on input multiplied by time and rotSpeed
            currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotSpeed;
            //Moving the value of vector 3 into quaternion.Angle
            currentRotation.eulerAngles = currentEulerAngles;
            //Rotates the game object on the QuaternionAngle
            transform.rotation = currentRotation;
        }

    void QuaternionRotateTowards()
    {
        //Copies the rotation values of another object
        var step = rotSpeed * Time.time;
        transform.rotation =
        Quaternion.RotateTowards(transform.rotation, targetA.rotation, step);
    }

    void QuaternionSlerp()
    {
        transform.rotation = Quaternion.Slerp(targetA.rotation, targetB.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;

    }

    void LookRotation()
    {
        Vector3 relativePos = targetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
