//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    /// <summary>
    /// sets up boss to do an attack
    /// picks a random one
    /// affter attacks switch to cooldown
    /// </summary>
    public class BossStateAttack : BossState
    {
        public static bool spawn; // allows other sript to see if spawn is true dont think i need but just in case
        float timer;// keeps track of time
        float time = 10;// how long should attack for
        public BossController other; // gets script
        bool random;// sees if random is true
        int attack; // waht attack to preform
        /// <summary>
        /// overides update to do the attacks
        /// after chosing one it will prefrom it for the duration unless damged and after it is done with attack will switch to cooldown
        /// </summary>
        /// <param name="boss"></param>
        /// <returns></returns>
        public override BossState Update(BossController boss)
        {
          if (random == false)
            {
                attack = Random.Range(1,4 );
                random = true;
            } 
          //  Debug.Log(attack);
            if (attack == 1)
            {
                boss.SpawnBasicEnemy();
                time = 5;
            }
            if (attack == 2)
            {
                boss.SpawnChargeEnmey();
                time = 2;
            }
            if (attack == 3)
            {
                boss.Charge();
                time = 1f;
            }
            //spawn = true;
            timer += Time.deltaTime;
            if (  timer >= time)
            {
                random = false;
                return new BossStateCoolDown();

            }
            if (EnemyHit.hit == true)
            {
                return new BossStateDamged();
            }
            return null;

        }
    }
}
