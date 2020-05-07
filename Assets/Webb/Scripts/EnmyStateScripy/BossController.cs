using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    /// <summary>
    /// this bosss
    /// this is the main script on the boss and is where the main update will be overrided
    /// holds all functions that the other scripts will need to acces
    /// </summary>
    public class BossController : MonoBehaviour
    {
        public float speed = 10; // how fast boss can move
        public float VisionDistanceThreshold = 40; // how far he can see
        public float pursueDistanceThreshold = 40; //how close the boss will get
        public float timer;// keeps track of set time
        public int attack; // what type of attack the boss does
        Vector3 spawnPos;// keeps track of where the boss is located in level
        [HideInInspector]// hides properties from inspector while leaving them accesible to other scripts
        public Vector3 velocity = new Vector3(); // keeps track of speed
        BossState currentState;// keps track of what script boss is runing
        public ChargeEnmey prefabChargeEnmey;// holds the charge enmy for spawing during attack
        public BasicEnemy prefabBasicEnemy;// holds the basic enmey for spawing during attack

        public Transform attackTarget { get; private set; }// gets the attack target and makes so it cant change
        // Start is called before the first frame update
        /// <summary>
        /// finds the player and then if the player was null it sets it to player 
        /// </summary>
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform;

        }

        // Update is called once per frame
        /// <summary>
        /// switchs the state into another script
        /// if null will go to bossstate idel
        /// allows for swithcing states
        /// </summary>
        void Update()
        {
            if (currentState == null) SwitchToState(new BossStateIdel());
            if (currentState != null) SwitchToState(currentState.Update(this));
           

        }
       /// <summary>
       /// used for swithcing states
       /// </summary>
       /// <param name="newState"></param> used for calling functions from this script
        private void SwitchToState(BossState newState)
        {
            if (newState != null)
            {
                if (currentState != null) currentState.OnEnd(this);

                currentState = newState;
                currentState.OnStart(this);
            }
        }
    
        /// <summary>
        /// finds the current direction towards the player 
        /// </summary>
        /// <returns></returns>
        public Vector3 VectorToAttackTarget()
        {
return  attackTarget.position - transform.position;
        }
public float distanceToAttackTarget()
        {
            return VectorToAttackTarget().magnitude;
        }

        /// <summary>
        /// checks for wether or not the player is visble to the boss
        /// </summary>
        /// <returns></returns>
        public bool CanSeeAttackTarget()
        {
            if (attackTarget == null) return false;

            {
                Vector3 vectorBetween = VectorToAttackTarget();
                
                if (vectorBetween.sqrMagnitude < VisionDistanceThreshold * VisionDistanceThreshold)
                {
                  //  return true;
                    //player is close enogue to boss to activate it
                    Ray ray = new Ray(transform.position, vectorBetween.normalized);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                        Debug.DrawRay(transform.position, forward, Color.green);
                        if (hit.transform == attackTarget) return true;
                        //clear line of vision


                        // if distances < thershold && raycast from player to boss hits..
                        // transtion to prsue

                    }
                }
            }
            return false;
        }
        /// <summary>
        /// gets the dir to player and speeds up at the player for a fast attack
        /// </summary>
        public void Charge()
        {
            Vector3 dirToPlayer = (attackTarget.position - transform.position).normalized;
            transform.position += dirToPlayer * speed * 2 * Time.deltaTime;
          
        }
        /// <summary>
        /// forces the boss away from player
        /// </summary>
        public void Retreat()
        {

            transform.position += Vector3.right* 20 * Time.deltaTime;

        }
        /// <summary>
        /// makes the boss chase after the player
        /// </summary>
        public void Follow()
        {
            Vector3 vectorToPlayer = VectorToAttackTarget();
            Vector3 dirToPlayer = (attackTarget.position - transform.position).normalized;
            transform.position += dirToPlayer * speed * Time.deltaTime;
        }
        /// <summary>
        /// Instantiate the charge enmey to attack the player
        /// </summary>
        public void SpawnChargeEnmey()
        {
            timer += Time.deltaTime;
            if (timer >= .7) { 
            
            spawnPos = gameObject.transform.position;
                ChargeEnmey newChargeEnemy = Instantiate(prefabChargeEnmey, spawnPos, Quaternion.identity);
            timer = 0;
        }
        }    
        /// <summary>
             /// Instantiate the basic enmey to attack the player
             /// </summary>
        public void SpawnBasicEnemy()
        {
            timer += Time.deltaTime;
            if (timer >= 1.2)
            {

                spawnPos = gameObject.transform.position;
                BasicEnemy newBasicEnemy = Instantiate(prefabBasicEnemy, spawnPos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}


