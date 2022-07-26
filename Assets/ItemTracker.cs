using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.GameResources
{
    public class ItemTracker : MonoBehaviour
    {
        Dictionary<ResourceType, List<GameObject>> ResourceTracker = new Dictionary<ResourceType, List<GameObject>>();
        private void Start()
        {
            foreach(GameResource resource in FindObjectsOfType<GameResource>())
            {
                if(!ResourceTracker.ContainsKey(resource.GetResourceType())) ResourceTracker.Add(resource.GetResourceType(), new List<GameObject>());
                foreach (KeyValuePair<ResourceType, List<GameObject>> kvp in ResourceTracker)
                {
                    if(kvp.Key.Equals(resource.GetResourceType()))
                    {
                        ResourceTracker[kvp.Key].Add(resource.gameObject);
                    }
                }
            }
        }
        public Dictionary<ResourceType, List<GameObject>> getResourceState()
        {
            return ResourceTracker;
        }
    }
}
