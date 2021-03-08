
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Thrower thrower;
    public Spawner spawner;



    void Start()
    {
        thrower.Initialize();
        spawner.Initialize();
      
    }

   
}
