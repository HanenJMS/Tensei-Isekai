using IsekaiRPG.AI.GOAP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP.Action
{
    public class HuntTargets : GAction
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            GWorld.Instance.GetWorld().ModifyState("Hunting", 1);
            //GWorld.Instance.addHunter(this.gameObject);
            return true;
        }
    }
}