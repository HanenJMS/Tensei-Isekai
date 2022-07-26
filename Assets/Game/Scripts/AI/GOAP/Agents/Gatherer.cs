using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.GameResources;

namespace IsekaiRPG.AI.GOAP
{
    public class Gatherer : GAgent
    {
        JobType jobType;
        public int demand;
        new void Start()
        {
            base.Start();
            jobType = JobType.Gatherer;
            SubGoal foundResource = new SubGoal("foundResource", demand, true);
            SubGoal hasResources = new SubGoal("hasResource", demand, true);
            goals.Add(foundResource, demand);
            goals.Add(hasResources, demand);
        }
    }
}