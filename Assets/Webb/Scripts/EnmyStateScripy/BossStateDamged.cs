using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    /// <summary>
    /// sets up if enmey for retreat after damge and returns to idel after retreating
    /// </summary>
    public class BossStateDamged : BossState
    {
        float timer;//  how much time has passed
        float time = 1;// how long it should retreat
        public override BossState Update(BossController boss)
        {   boss.Retreat();//cals rtreat function
            timer += Time.deltaTime;//adds time
            if (timer >= time)
            {
             return new BossStateIdel();    //puts back to idels state
             
            }

            return null;
        }
    }
}