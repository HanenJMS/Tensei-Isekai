using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace IsekaiRPG.AI.GOAP
{
    public abstract class GAction : MonoBehaviour
    {
        public string actionName = "Action";
        public float cost = 1.0f;
        public GameObject target;
        public string targetTag;
        public float duration = 0;
        public WorldState[] preConditions;
        public WorldState[] afterEffects;
        public NavMeshAgent agent;
        public Dictionary<string, int> preconditions;
        public Dictionary<string, int> effects;
        public WorldStates agentBeliefs;
        public bool isRunning = false;
        public GAction()
        {
            preconditions = new Dictionary<string, int>();
            effects = new Dictionary<string, int>();
        }
        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            InitializingDictionaries();
            agentBeliefs = gameObject.GetComponent<GAgent>().beliefs;
        }
        public bool IsActionAchievable()
        {
            return true;
        }
        public bool IsActionAchievableGiven(Dictionary<string, int> conditions)
        {
            foreach(KeyValuePair<string, int> pre in preconditions)
            {
                if (!conditions.ContainsKey(pre.Key)) return false;
            }
            return true;
        }
        public abstract bool PrePerform();
        public abstract bool PostPerform();
        private void InitializingDictionaries()
        {
            //populating precondition and effects dictionary from the WorldState list
            if (preConditions != null)
            {
                foreach (WorldState state in preConditions)
                {
                    preconditions.Add(state.key, state.value);
                }
            }
            if (afterEffects != null)
            {
                foreach (WorldState state in afterEffects)
                {
                    effects.Add(state.key, state.value);
                }
            }
        }

    }
}
