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
        [SerializeField] ResourceType resourceDemanded = ResourceType.Wood;
        public override bool PrePerform()
        {
            
            return true;
        }
        public override bool PostPerform()
        {
            if (quantity > GameObject.FindObjectsOfType<GameResource>().Length) return false;
            foreach (GameResource resource in GameObject.FindObjectsOfType<GameResource>())
            {
                if (resource.GetResourceType().Equals(resourceDemanded))
                {
                    if (Vector3.Distance(this.gameObject.transform.position, resource.gameObject.transform.position) < searchDistance)
                    {
                        GWorld.Instance.AddResource(resource.gameObject, resourceDemanded);
                    }
                }
            }
            return true;
        }
    }
}
