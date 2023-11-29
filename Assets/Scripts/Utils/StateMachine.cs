using States;
using UnityEngine;

public interface IStateMachine
{
    public void TransitionTo(State newState);
}

public abstract class State
{
    protected GameManager _context;
    public virtual string Name { get; set; }

    public State(GameManager context)
    {
        this._context = context;
    }

    public abstract void HandleEvent(Action action);
}