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
        [SerializeField] ResourceType resourceDemanded = ResourceType.Wood;
        public override bool PrePerform()
        {
            target = GWorld.Instance.RemoveResource(resourceDemanded);
            if(target == null) return false;
            return true;
        }
        public override bool PostPerform()
        {
            return true;
        }
    }
}
