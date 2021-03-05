using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject ball;
    public GameObject target;
    public bool readyToThrow;
    public bool destroyObjects;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (readyToThrow)
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Ground"))
                {
                    Instantiate(target, new Vector3(hit.point.x,0,hit.point.z), Quaternion.identity);
                }

                destroyObjects = true;
                readyToThrow = false;
            }
            else
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (destroyObjects && Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Ground"))
                {
                    Destroy (GameObject.FindWithTag("Ball"));
                    Destroy (GameObject.FindWithTag("Target"));
                    destroyObjects = false;
                } else if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("UI"))
                {
                    destroyObjects = true;
                }
                else
                {
                    
                    if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Ground"))
                    {
                        
                        Instantiate(ball, new Vector3(hit.point.x,0,hit.point.z), Quaternion.identity);
                    }
                    readyToThrow = true;
                }
            }
          
        }
    }
}
