using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrower : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;
    public float throwingAngle ;
    public float gravity;
    public float targetDistance;
    public float velocity;
    public bool inThrow;
    public Vector3 startObjectFirstPos;
    public Slider speedSlider;
    public Slider hMaxSlider;


    private void Start()
    {
        gravity = 10;
        throwingAngle = 45;
    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             Throw();
         }

         if (inThrow)
         {
             speedSlider.enabled = false;
             hMaxSlider.enabled = false;
         }
         else
         {
             speedSlider.enabled = true;
             hMaxSlider.enabled = true;
         }
    }
    public void Throw()
    {
        startObject = GameObject.FindWithTag("Ball");
        endObject = GameObject.FindWithTag("Target");
        StartCoroutine(SimulateProjectile());
        inThrow = true;
    }
    IEnumerator SimulateProjectile()
    {
         targetDistance = Vector3.Distance(startObject.transform.position, endObject.transform.position);
         startObjectFirstPos = startObject.transform.position;
        
         velocity = Mathf.Sqrt((targetDistance * gravity) / Mathf.Sin(2 * throwingAngle * Mathf.Deg2Rad)) ;
         
        float Vx = velocity * Mathf.Cos(throwingAngle * Mathf.Deg2Rad);
        float Vy = velocity * Mathf.Sin(throwingAngle * Mathf.Deg2Rad);
        
        float flightDuration = targetDistance / Vx;
        
        startObject.transform.rotation = Quaternion.LookRotation(endObject.transform.position - startObject.transform.position);
       
        float elapseTime = 0;
        while (elapseTime < flightDuration)
        {
            startObject.transform.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);
           
            elapseTime += Time.deltaTime;
            yield return null;
        }

        if (Mathf.RoundToInt(targetDistance) == 0 )
        {
            inThrow = false;
        }
        if (inThrow)
        {
            endObject.transform.position += ((endObject.transform.position - startObjectFirstPos)*2)/5;
            endObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(SimulateProjectile());
        }
      
    }

    public void ChangeSpeed(float newSpeed)
    {
        gravity = newSpeed;
    }

    public void ChangeHMax(float newHMax)
    {
        throwingAngle = newHMax;
    }
  
}
