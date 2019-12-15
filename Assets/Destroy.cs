using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// used to destoy object when player jumps on it
/// </summary>
public class Destroy : MonoBehaviour
{
   /// <summary>
   /// checks if player clooides with it and destroys everthing
   /// </summary>
   /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
            {
            Destroy(transform.parent.gameObject);
            
        }
    }
}
