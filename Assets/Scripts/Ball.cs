using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TrailRenderer trail;
    void Start()
    {
        trail.endColor = new Color32(1, 1, 1, 0);
        trail.endWidth = .2f;
    }



}
