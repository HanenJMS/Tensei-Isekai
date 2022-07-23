using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiRPG.AI.GOAP
{
    [System.Serializable]
    public class WorldState
    {
        public string key;
        public int value;
    }
    public class WorldStates
    {
        public Dictionary<string, int> states;
        public WorldStates()
        {
            states = new Dictionary<string, int>();
        }
        public Dictionary<string, int> GetStates()
        {
            return states;
        }
        public bool HasState(string key)
        {
            return states.ContainsKey(key);
        }
        public void ModifyState(string key, int value)
        {
            if(HasState(key))
            {
                states[key] += value;
                if(states[key] <= 0)
                {
                    RemoveState(key);
                }
            }
            else
            {
                AddState(key, value);
            }
        }
        public void SetState(string key, int value)
        {
            if(HasState(key))
            {
                states[key] = value;
            }
            else
            {
                AddState(key, value);
            }
        }
        private void AddState(string key, int value)
        {
            if (HasState(key)) return;
            states.Add(key, value);
        }
        private void RemoveState(string key)
        {
            if (!HasState(key)) return;
            states.Remove(key);
        }
    }
}
