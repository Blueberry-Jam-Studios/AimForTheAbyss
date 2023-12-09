using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


/// <summary>
/// Our objective is to implement a finite state machine using 
/// the class based approach.
/// 
/// What is a finite state mcahine?
/// A finite state machine is a computational pattern that models 
/// the state behaviour of a system. Such a system comprises a 
/// finite number of states and at any given point in time the
/// system exists in only one state.
/// 
/// What we need?
/// 1. State
/// This is a data structure (class) that encapsulates the 
/// state related functionlities.
/// 
/// 2. The State Machine itself. 
/// This is the class that will manage all the states and the transitions.
/// </summary>


namespace Patterns
{
    public class State<T>
    {
        public string Name { get; set; }
        
        protected FiniteStateMachine<T> m_fsm;
        public State(FiniteStateMachine<T> fsm)
        {
            m_fsm = fsm;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }

    public class FiniteStateMachine<T>
    {
        public Dictionary<T, State<T>> States { get; set; } = new();
        public State<T> CurrentState { get; private set; }

        public void Add(T key, State<T> state)
        {
            States.Add(key, state);
        }

        public State<T> GetState(T key)
        {
            return States[key];
        }

        public void SetCurrentState(State<T> state)
        {
            CurrentState?.Exit();

            CurrentState = state;

            CurrentState?.Enter();
        }

        public void SetCurrentState(T stateID)
        {
            State<T> state = GetState(stateID);
            SetCurrentState(state);
        }

        public void Update( )
        {
            CurrentState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
    }
       
}