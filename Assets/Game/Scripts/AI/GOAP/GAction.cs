using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace IsekaiRPG.AI.GOAP
{
    public abstract class GAction : MonoBehaviour
    {
        [SerializeField] string actionName = "Action";
        [SerializeField] float cost = 1.0f;
        [SerializeField] GameObject target;
        [SerializeField] GameObject targetTag;
        [SerializeField] float duration = 0;
        [SerializeField] WorldState[] preConditions;
        [SerializeField] WorldState[] afterEffects;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] Dictionary<string, int> preconditions;
        [SerializeField] Dictionary<string, int> effects;
        [SerializeField] WorldStates agentBeliefs;
        [SerializeField] bool isRunning = false;
        public GAction()
        {
            preconditions = new Dictionary<string, int>();
            effects = new Dictionary<string, int>();
        }
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            InitializingDictionaries();
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
