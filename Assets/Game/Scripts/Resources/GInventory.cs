using RPG.GameResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
    List<IResource> resources = new List<IResource>();
    public void AddItem(IResource resource)
    {
        resources.Add(resource);
    }
    public void RemoveResource(IResource resource)
    {
        int indexToRemove = -1;
        foreach (IResource r in resources)
        {
            indexToRemove++;
            if (r == resource)
            {
                break;
            }
        }
        if (indexToRemove > -1)
        {
            resources.RemoveAt(indexToRemove);
        }
    }
}
