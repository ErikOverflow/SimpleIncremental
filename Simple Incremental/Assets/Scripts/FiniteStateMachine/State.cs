using UnityEngine;

namespace ErikOverflow.FiniteStateMachine
{
    public abstract class State<T> : ScriptableObject where T : CharStateData
    {
        public abstract Action<T>[] GetActions();
        public abstract Transition<T>[] GetTransitions();

        public void UpdateState(StateController<T> controller)
        {
            DoActions(controller.stateData);
            CheckTransitions(controller);
        }

        private void DoActions(T data)
        {
            Action<T>[] actions = GetActions();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(data);
            }
        }

        void CheckTransitions(StateController<T> controller)
        {
            Transition<T>[] transitions = GetTransitions();
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].GetDecision().Decide(controller.stateData))
                    controller.TransitionToState(transitions[i].GetTrueState());
                else
                    controller.TransitionToState(transitions[i].GetFalseState());
            }
        }
    }
}