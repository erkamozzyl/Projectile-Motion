
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TrailRenderer trail;
   

    public void Start()
    {
        trail.endColor = new Color32(1, 1, 1, 0);
        trail.endWidth = .2f;
    }

}
