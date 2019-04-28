using UnityEngine;

namespace ErikOverflow.FiniteStateMachine
{
    public abstract class Decision<T> : ScriptableObject where T : CharStateData
    {
        public abstract bool Decide(T data);
    }
}