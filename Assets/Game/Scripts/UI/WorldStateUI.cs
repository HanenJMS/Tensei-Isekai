using IsekaiRPG.AI.GOAP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace IsekaiRPG.UI
{
    public class WorldStateUI : MonoBehaviour
    {
        Text worldStateTracker;
        private void Start()
        {
            worldStateTracker = GetComponent<Text>();
        }
        private void Update()
        {
            Dictionary<string, int> worldstates = GWorld.Instance.GetWorld().GetStates();
            foreach (KeyValuePair<string, int> state in worldstates)
            {
                worldStateTracker.text = state.Key + ", " + state.Value;
            }
        }
    }
}
