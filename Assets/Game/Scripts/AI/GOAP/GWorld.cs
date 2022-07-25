using RPG.GameResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new GWorld();
        private static WorldStates world;
        private static Dictionary<ResourceType, Queue<GameResource>> gameResources;
        static GWorld()
        {
            world = new WorldStates();
            gameResources = new Dictionary<ResourceType, Queue<GameResource>>();
        }
        private GWorld()
        {
        }
        public void AddResource(GameResource gameResource)
        {
            if (!gameResources.ContainsKey(gameResource.GetResourceType()))
            {
                gameResources.Add(gameResource.GetResourceType(), new Queue<GameResource>());
            }
            foreach(KeyValuePair<ResourceType, Queue<GameResource>> kvp in gameResources)
            {
                if(kvp.Key.Equals(gameResource.GetResourceType()))
                {
                    kvp.Value.Enqueue(gameResource);
                    return;
                }
            }
        }
        public GameResource RemoveResource(ResourceType gameResourceType)
        {
            GameResource giveResource = null;
            if (!gameResources.ContainsKey((gameResourceType)))
            {
                Debug.Log("No Resource type requested. GWorld.cs (40). check references for RemoveResource().");
                return null;
            }
            foreach(KeyValuePair<ResourceType, Queue<GameResource>> kvp in gameResources)
            {
                if(kvp.Key.Equals((gameResourceType)))
                {
                    giveResource = kvp.Value.Dequeue();
                }
            }
            return giveResource;
        }
        public static GWorld Instance
        {
            get { return instance; }
        }
        public WorldStates GetWorld()
        {
            return world;
        }
    }
}
