using RPG.GameResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP
{
    public class FindResources : GAction
    {
        public float quantity;
        public float searchDistance;
        ResourceType resourceDemanded = ResourceType.Wood;
        public override bool PrePerform()
        {
            foreach (GameResource resource in GameObject.FindObjectsOfType<GameResource>())
            {
                if(resource.GetResourceType().Equals(resourceDemanded))
                {
                    if(Vector3.Distance(resource.gameObject.transform.position, this.gameObject.transform.position) < searchDistance)
                    {

                    }
                }
            }
            if (quantity > 0)
            {
                return false;
            }
            return true;
        }
        public override bool PostPerform()
        {
            return true;
        }

        
    }
}
