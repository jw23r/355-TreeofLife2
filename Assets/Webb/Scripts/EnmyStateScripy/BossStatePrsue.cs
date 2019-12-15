using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{/// <summary>
/// this class sets up chasing the enemy
/// </summary>
    public class BossStatePrsue : BossState
    {
        // Start is called before the first frame update
        /// <summary>
        /// overides the boss update behavior
        /// and is lloking to chase enemy and when inrange swithc to attakc
        /// also checks for being damged
        /// </summary>
        /// <param name="boss"></param> refrence of the main script
        /// <returns></returns>
        public override BossState Update(BossController boss)
        {//////////// State Behavior
         // move towards player
           Vector3 vectorToPlayer = boss.VectorToAttackTarget();
           /* Vector3 dirToPlayer = (boss.attackTarget.position - boss.transform.position).normalized;
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;
          */  boss.Follow();
            /////////////////////// transtions:
            if (EnemyHit.hit == true)
            {
                return new BossStateDamged();
            }
            if (vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)// if dis < htrshold 
           
            {                                                    // transtion to attack 
                return new BossStateAttack();
            }

                if (!boss.CanSeeAttackTarget())  /// if we cant see player...
            return new BossStateIdel();/// transtion to idle
            return null;
        }
    }
}
