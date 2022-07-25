using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP 
{
    public class Soldier : GAgent
    {
        JobType jobType;
        new void Start()
        {
            base.Start();
            jobType = JobType.Soldier;
            SubGoal hasFinishedPatrol = new SubGoal("hasFinishedPatrol", 1, true);
            goals.Add(hasFinishedPatrol, 3);
        }
    }
}
