using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace IsekaiRPG.AI.GOAP
{
    public class Node
    {
        public Node parent;
        public float cost;
        public Dictionary<string, int> state;
        public GAction action;
        public Node(Node parent, float cost, Dictionary<string, int> allStates, GAction action)
        {
            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            this.action = action;
        }
    }
    public class GPlanner
    {
        public Queue<GAction> plan(List<GAction> actions, Dictionary<string, int> goal, WorldStates states)
        {
            List<GAction> usableActions = new List<GAction>();
            foreach (GAction action in actions)
            {
                if(action.IsActionAchievable())
                {
                    usableActions.Add(action);
                }
            }
            List<Node> leaves = new List<Node>();
            Node start = new Node(null, 0, GWorld.Instance.GetWorld().GetStates(), null);
            bool successful = BuildGraph(start, leaves, usableActions, goal);
            if(!successful)
            {
                Debug.Log("No Plan available GPlanner.cs(38)");
                return null;
            }
            Node cheapest = null;
            foreach(Node leaf in leaves)
            {
                if(cheapest == null)
                {
                    cheapest = leaf;
                }
                else
                {
                    if (leaf.cost < cheapest.cost)
                    {
                        cheapest = leaf;
                    }
                }
            }
            List<GAction> planningResult = new List<GAction>();
            Node thisPlanNode = cheapest;
            while(thisPlanNode != null)
            {
                if(thisPlanNode.action != null)
                {
                    planningResult.Insert(0, thisPlanNode.action);
                }
                thisPlanNode = thisPlanNode.parent;
            }
            Queue<GAction> queue = new Queue<GAction>();
            foreach(GAction action in planningResult)
            {
                queue.Enqueue(action);
            }
            Debug.Log("The Plan is: ");
            foreach(GAction action in queue)
            {
                Debug.Log($"!Q: {action.actionName}");
            }
            return queue;
        }
        private bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string, int> goal)
        {
            bool foundPath = false;
            foreach (GAction action in usableActions)
            {
                if(action.IsActionAchievableGiven(parent.state))
                {
                    Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                    foreach(KeyValuePair<string, int> effect in action.effects)
                    {
                        if(!currentState.ContainsKey(effect.Key))
                        {
                            currentState.Add(effect.Key, effect.Value);
                        }
                    }
                    Node node = new Node(parent, parent.cost + action.cost, currentState, action);
                    if(GoalIsAchieved(goal, currentState))
                    {
                        leaves.Add(node);
                        return true;
                    }
                    else
                    {
                        List<GAction> subset = ActionSubset(usableActions, action);
                        bool found = BuildGraph(node, leaves, subset, goal);
                        if(found)
                        {
                            foundPath = true; 
                        }
                    }
                }
            }
            return foundPath;
        }
        private bool GoalIsAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
        {
            foreach(KeyValuePair<string, int> g in goal)
            {
                if(!state.ContainsKey(g.Key))
                {
                    return false;
                }
            }
            return true;
        }
        private List<GAction> ActionSubset(List<GAction> actions, GAction removeAction)
        {
            List<GAction> subset = new List<GAction>();
            foreach(GAction action in actions)
            {
                if(!action.Equals(removeAction))
                {
                    subset.Add(action);
                }
            }
            return subset;
        }
    }
}