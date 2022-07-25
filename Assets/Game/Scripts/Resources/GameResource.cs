using IsekaiRPG.AI.GOAP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.GameResources
{
    public class GameResource : MonoBehaviour, IResource
    {
        [SerializeField] ResourceType resourceType;

        public ResourceType GetResourceType()
        {
            return resourceType;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<GAgent>().inventory.AddItem(this);
            Destroy(this.gameObject);
        }
    }
}
