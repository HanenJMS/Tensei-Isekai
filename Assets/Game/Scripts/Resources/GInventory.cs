using RPG.GameResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
    Dictionary<ResourceType, List<GameObject>> resourceInventory = new Dictionary<ResourceType, List<GameObject>>();
    public void AddItem(GameObject resource, ResourceType resourceType)
    {
        if(!resourceInventory.ContainsKey(resourceType)) resourceInventory.Add(resourceType, new List<GameObject>());
        foreach(KeyValuePair<ResourceType, List<GameObject>> kvp in resourceInventory)
        {
            if(kvp.Key == resourceType)
            {
                kvp.Value.Add(resource);
            }
        }
    }
    public void RemoveResource(GameObject resource)
    {
        int indexToRemove = -1;
        foreach (GameObject r in resourceInventory[resource.GetComponent<GameResource>().GetResourceType()])
        {
            indexToRemove++;
            if (r == resource)
            {
                break;
            }
        }
        if (indexToRemove > -1)
        {
            resourceInventory[resource.GetComponent<GameResource>().GetResourceType()].RemoveAt(indexToRemove);
        }
    }
}
