using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class ChargeEnmey : MonoBehaviour
    {
        GameObject owner;


        float lifeTime = 15;// stores how long the bullet should be alive before destroying it
        int speed = 2;// how fast this object can move
        float age;// kepps track how long its been spawned
                  /// <summary>
                  /// sets this object owner to istslef
                  /// </summary>
                  /// <param name="owner"></param>
        public void Shoot(GameObject owner)
        {
            this.owner = owner;
        }
        public Transform attackTarget { get; private set; }//gets the attack target and makes so it cant change
                                                           /// <summary>
                                                           /// sets the value of offset to a random range
                                                           /// finds the player and then if the player was null it sets it to player 
                                                           /// </summary>
        // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform;

        }
     /// <summary>
     /// sets up  to check how far away player is and moves towards player when in range sprints at tarrget
     /// </summary>
        // Update is called once per frame
        void Update()
        {
            Vector3 dirToPlayer = (attackTarget.position - transform.position);
            transform.position += dirToPlayer.normalized * speed * Time.deltaTime;
            if (dirToPlayer.x <= 5)
            {
                speed = 15;
            }
            if (dirToPlayer.x  > 5  )
            {
                speed = 2;
            }
            age += Time.deltaTime;
            if (age >= lifeTime)
            {
                Destroy(gameObject);
            }
        }
    /// <summary>
     /// checks to make sure its not colliding with player and not itself
     /// destorys when hits palyer 
     /// when hits player deals damge
     /// </summary>
    void OnTriggerEnter(Collider collider)
           

        {
            if (collider.gameObject == owner) return;
            if (collider.transform.tag == "Player") {
                    print("projectile hit something");
                    Destroy(gameObject);
                HUDControler.playerHealth -= 15;
                }
        }
    }
}
