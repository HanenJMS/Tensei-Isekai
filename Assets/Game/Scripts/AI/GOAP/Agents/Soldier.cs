using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP 
{
    public class Soldier : GAgent
    {
        new void Start()
        {
            base.Start();
            SubGoal s1 = new SubGoal("isHunting", 1, true);
            goals.Add(s1, 3);
        }
    }
}
