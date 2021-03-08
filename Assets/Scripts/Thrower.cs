
using System.Collections;
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
    public Slider bouncinessSlider;
    public float bounciness;


  

    public void Initialize()
    {
        gravity = 10;
        throwingAngle = 45;
        bounciness = 0.5f;
    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && !inThrow)
         {
             Throw();
         }

         if (inThrow)
         {
             speedSlider.interactable = false;
             hMaxSlider.interactable = false;
             bouncinessSlider.interactable = false;
         }
         else
         {
             bouncinessSlider.interactable = true;
             speedSlider.interactable = true;
             hMaxSlider.interactable = true;
         }
    }
    public void Throw()
    {
        startObject = GameObject.FindWithTag("Ball");
        endObject = GameObject.FindWithTag("Target");
        inThrow = true;
        StartCoroutine(SimulateProjectile());
        
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
            while (elapseTime < flightDuration && inThrow )
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
                endObject.transform.position += (endObject.transform.position - startObjectFirstPos)*bounciness;
                endObject.transform.position += new Vector3(0,.05f,0);
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

    public void ChangeBounciness(float newBounciness)
    {
        bounciness = newBounciness;
      
    }
  
}
