using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{/// <summary>
/// sets up state  state design pattern
/// </summary>
    public abstract class BossState
    {
        public abstract BossState Update(BossController boss);
        public virtual void OnStart(BossController boss) { }
        public virtual void OnEnd(BossController boss) { }

    }
}
