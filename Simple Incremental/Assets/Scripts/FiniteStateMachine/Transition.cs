using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.FiniteStateMachine
{
    [Serializable]
    public abstract class Transition<T> where T : CharStateData
    {
        public abstract Decision<T> GetDecision();
        public abstract State<T> GetTrueState();
        public abstract State<T> GetFalseState();
    }
}