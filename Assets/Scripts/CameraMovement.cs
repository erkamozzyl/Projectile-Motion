using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraMovementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,1,1) * (cameraMovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,-1,-1) * (cameraMovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (cameraMovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (cameraMovementSpeed * Time.deltaTime));
        }
        
    }
}
