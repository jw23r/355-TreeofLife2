using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb { 
    /// <summary>
    /// makes the boss do nothing well recharging from attacking
    /// </summary>
    public class BossStateCoolDown : BossState
    {
        float timer;// kepps track of time should br refactoed into function
        // Start is called before the first frame update
        public override BossState Update(BossController boss)
        {
            //Debug.Log("cooling off");
            timer += Time.deltaTime; // ads time to timer
            if(timer >= 5)
            {
                return new BossStateIdel();
            }
            if (EnemyHit.hit == true)
            {
                return new BossStateDamged();
            }
            return null;
        }
    }
}
