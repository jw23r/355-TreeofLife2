using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{/// <summary>
/// this checks if player has hit ememy and if so damges and lets enmey know to switch to damged state 
/// </summary>
    public class EnemyHit : MonoBehaviour
    {
        // Start is called before the first frame update
        public static bool hit; //checks wether or not enemy is damged 
        void OnTriggerEnter(Collider collider)

            
        {
            
            if (collider.transform.tag == "Player") // checks if player
            {
                // print("hit");
                print("projectile hit something");
                HUDControler.enemyHealth -= 100;
                hit = true;
            }
        }
            void OnTriggerExit(Collider collider)


            {
                if (collider.transform.tag == "Player") // checks if player leaving
                {
                // print("hit");
                print("player gone");

                hit = false;
                }


            

        }
    }
}