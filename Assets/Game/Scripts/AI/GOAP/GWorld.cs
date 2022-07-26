using RPG.GameResources;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new GWorld();
        private static WorldStates world;
        private static Dictionary<ResourceType, Queue<GameObject>> gameResources;
        static GWorld()
        {
            world = new WorldStates();
            gameResources = new Dictionary<ResourceType, Queue<GameObject>>();
        }
        private GWorld()
        {
        }
        public void AddResource(GameObject gameResource, ResourceType resourceType)
        {
            if (!gameResources.ContainsKey(resourceType))
            {
                gameResources.Add(resourceType, new Queue<GameObject>());
            }
            foreach (KeyValuePair<ResourceType, Queue<GameObject>> kvp in gameResources)
            {
                if (kvp.Key.Equals(resourceType))
                {
                    kvp.Value.Enqueue(gameResource);
                    world.ModifyState("has", 1);
                }
            }
        }
        public GameObject RemoveResource(ResourceType gameResourceType)
        {
            GameObject giveResource = null;
            if (!gameResources.ContainsKey((gameResourceType)))
            {
                return null;
            }
            foreach (KeyValuePair<ResourceType, Queue<GameObject>> kvp in gameResources)
            {
                if (kvp.Key.Equals(gameResourceType))
                {
                    giveResource = kvp.Value.Dequeue();
                    world.ModifyState(gameResourceType.ToString(), -1);
                }
            }
            return giveResource;
        }
        public static GWorld Instance => instance;
        public WorldStates GetWorld()
        {
            return world;
        }
    }
}
