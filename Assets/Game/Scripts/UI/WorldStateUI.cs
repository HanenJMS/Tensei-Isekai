using IsekaiRPG.AI.GOAP;
using RPG.GameResources;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace RPG.UI
{
    public class WorldStateUI : MonoBehaviour
    {
        Text worldStateTracker;
        ItemTracker itemTracker;
        private void Start()
        {
            worldStateTracker = GetComponent<Text>();
            itemTracker = GetComponentInParent<ItemTracker>();
        }
        private void Update()
        {
            worldStateTracker.text = "";
            foreach(KeyValuePair<ResourceType, List<GameObject>> kvp in itemTracker.getResourceState())
            {
                worldStateTracker.text += Enum.GetName(typeof(ResourceType), kvp.Key) + ", " + kvp.Value.Count + "\n";
            }
        }
    }
}
