using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BasicEnemy : MonoBehaviour
    {
        GameObject owner; //  stores who owns this object
        Vector3 dirToPlayer;// holds the direction of the player
        Vector3 offSet;// used to offset the enmey from the players actual location
        float lifeTime = 15;// stores how long the bullet should be alive before destroying it
        int speed = 5;// how fast this object can move
        float age;// kepps track how long its been spawned
        /// <summary>
        /// sets this object owner to istslef
        /// </summary>
        /// <param name="owner"></param>
        public void Shoot(GameObject owner)
        {
            this.owner = owner;
        }
        //
        public Transform attackTarget { get; private set; }// gets the attack target and makes so it cant change
                                                           // Start is called before the first frame update
                                                           /// <summary>
                                                           /// sets the value of offset to a random range
                                                           /// finds the player and then if the player was null it sets it to player 
                                                           /// </summary>
        void Start()
        {
            offSet = new Vector3(0.0f, Random.Range(-2.0f, 3), 0.0f);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform;

        }

        // Update is called once per frame
        /// <summary>
        /// moves the object towards player and is sligthley off untill its age  and then moves dir to the taarget
        /// then if its reached its age limit is is destroyed
        /// </summary>
        void Update()
        {
            if (age <= 5)
            {
                dirToPlayer = (attackTarget.position - transform.position + offSet);
            }
            else
            {
               Vector3 dirToPlayer = (attackTarget.position - transform.position  );
            }
            transform.position += dirToPlayer.normalized * speed * Time.deltaTime;

            age += Time.deltaTime;
            if (age >= lifeTime)
            {
                Destroy(gameObject);
            }
        }/// <summary>
        /// checks to make sure its not colliding with player and not itself
        /// destorys when hits palyer 
        /// when hits player deals damge
        /// </summary>
        /// <param name="collider"></param>
        void OnTriggerEnter(Collider collider)


        {
            if (collider.gameObject == owner) return;
            if (collider.transform.tag == "Player")
            {
                print("projectile hit something");
                Destroy(gameObject);
                HUDControler.playerHealth -= 25;
            }
        }
    }
}