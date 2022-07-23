using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IsekaiRPG.AI.GOAP
{
    public class SubGoal
    {
        [SerializeField] Dictionary<string, int> sGoals;
        [SerializeField] public bool remove;
        public SubGoal(string s, int i, bool r)
        {
            sGoals = new Dictionary<string, int>();
            sGoals.Add(s, i);
            remove = r;
        }
    }
    public class GAgent : MonoBehaviour
    {
        public List<GAction> actions = new List<GAction>();
        public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
        Queue<GAction> actionQueue;
        public GAction currentAction;
        SubGoal currentGoal;
        private void Start()
        {
            GAction[] acts = this.GetComponents<GAction>();
            foreach(GAction act in acts)
            {
                actions.Add(act);
            }
        }
    }
}
