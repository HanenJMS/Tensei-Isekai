using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.GameResources;

namespace IsekaiRPG.AI.GOAP
{
    public class CollectResources : GAction
    {
        public float quantity;
        public float searchDistance;
        ResourceType resourceDemanded = ResourceType.Wood;
        public override bool PrePerform()
        {
            return true;
        }
        public override bool PostPerform()
        {
            //target = GWorld.Instance.RemoveWood();
            if (target == null) return false;
            GWorld.Instance.GetWorld().ModifyState("needWood", -1);
            return true;
        }
    }
}
