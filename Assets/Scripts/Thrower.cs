using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public int hMax;
    public float speed;
    public float firstPosX;
    public Vector3 destination;
    public float destinationY;
    public GameObject startObject;
    public GameObject endObject;
    public bool inThrow;

    
    void Start()
    {
        hMax = 10;
        speed = .5f;
        
        
    }


    private void Update()
    {
        
        if (inThrow)
        {
        startObject.transform.Translate(destination * (Time.deltaTime * speed));
     
     
          

          if (firstPosX < 0)
          {
             
              if (startObject.transform.position.x > firstPosX + destination.x / 2)
              {
                 
                  destination.y = destinationY - hMax;
              }
              else
              {
                  destination.y = hMax + destinationY;
                 
                  
              }
              if (startObject.transform.position.x > endObject.transform.position.x)
              {
                  inThrow = false;
              }
          }
          
          
          
          else
          {
            
              if (startObject.transform.position.x < firstPosX + destination.x / 2)
              {
                  destination.y = destinationY - hMax;
              }
              else
              {
                  destination.y = hMax + destinationY;
              }
            
              if (startObject.transform.position.x < endObject.transform.position.x)
              {
                  inThrow = false;
              }
          }
          
          
          
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Throw();
            }
        }
        
        



    }


    public void Throw()
    {
        startObject = GameObject.FindWithTag("Ball");
        endObject = GameObject.FindWithTag("Target");
     
        Debug.DrawLine(startObject.transform.position, endObject.transform.position, Color.red, 5,true);
        

        destination = endObject.transform.position - startObject.transform.position;
        firstPosX = startObject.transform.position.x;
        destinationY = destination.y;
  
        
        inThrow = true;
        

    }
    

}
