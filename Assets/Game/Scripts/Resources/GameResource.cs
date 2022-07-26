using IsekaiRPG.AI.GOAP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.GameResources
{
    public class GameResource : MonoBehaviour, IResource
    {
        [SerializeField] ResourceType resourceType;
        private void Start()
        {
            
        }
        
        public ResourceType GetResourceType()
        {
            return resourceType;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<GAgent>() == null) return;
            other.gameObject.GetComponent<GAgent>().inventory.AddItem(this.gameObject, this.gameObject.GetComponent<GameResource>().GetResourceType());
            Destroy(this.gameObject);
        }
    }
}
