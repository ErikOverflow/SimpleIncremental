using UnityEngine;

namespace ErikOverflow.FiniteStateMachine
{
    public abstract class StateController<T> : MonoBehaviour where T : CharStateData
    {
        public T stateData;
        public abstract State<T> GetCurrentState();
        public abstract void SetCurrentState(State<T> state);
        public abstract State<T> GetRemainState();
        private void Update()
        {
            GetCurrentState().UpdateState(this);
        }

        public void TransitionToState(State<T> nextState)
        {
            if (nextState != GetRemainState())
            {
                SetCurrentState(nextState);
            }
        }
    }
}