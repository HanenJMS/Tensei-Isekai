using IsekaiRPG.AI.GOAP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP.Action
{
    public class CaptureTarget : GAction
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            return true;
        }
    }
}

