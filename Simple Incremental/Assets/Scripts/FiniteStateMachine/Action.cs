using UnityEngine;

namespace ErikOverflow.FiniteStateMachine
{
    public abstract class Action<T> : ScriptableObject where T : CharStateData
    {
        public abstract void Act(T data);
    }
}