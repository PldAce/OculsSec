using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public bool enter = true;


    private void OnTriggerEnter(Collider other)
    {
        
  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Bsphere")
        {
            other.transform.position = new Vector3(7, 1, 10);
        }
    }
}
