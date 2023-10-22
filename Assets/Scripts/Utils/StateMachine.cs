using UnityEngine;

public interface IStateMachine
{

}

public abstract class State
{
    protected GameManager _context;

    public string Name { get => this.GetType().Name; }

    public State(GameManager context)
    {
        this._context = context;
    }

    public abstract void HandleEvent(KeyCode keycode);
}