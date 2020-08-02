using UnityEngine;

public abstract class BaseTurnState : MonoBehaviour
{

    protected StateMachineManager stateMachineManager { get; private set; }

    /// <summary>
    /// Handle any incoming events which may result in the state transitioning or require some kind of response.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    /// <param name="eventType">The event which occured</param>
    /// <param name="context">An additional context object which contains state relevent to the event</param>
    public abstract void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context);

    /// <summary>
    /// Called on the current state when a transition to the next state is about to occur.
    /// </summary>
    /// <param name="nextState">The next state that the state machine will transition to</param>
    public virtual void OnExitState(BaseTurnState nextState)
    {
        Debug.Log($"Transitioning away from {this.name}.");
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Gives the next state that will be transitioned to an opportunity to perform any required setup.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    public virtual void OnEnterState()
    {
        Debug.Log($"Transitioning into {this.name}.");
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Pass in a state machine which will manage this state's lifecycle.
    /// 
    /// You *probably* don't want to use this unless you know what you're doing
    /// and have some need for passing this state to another state machine.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state will belong to</param>
    public void ConfigureStateMachineManager(StateMachineManager manager)
    {
        this.stateMachineManager = manager;
    }

    // TODO: LifeCycle method for triggering a final transition into a terminal state in TurnStateMachine?

    public void Awake()
    {
        // States are explicitly disabled upon starting, and only become active
        // when a TurnManager or something else explicitly enables them.
        // The TurnManager does its own housekeeping of the current (active) state.
        gameObject.SetActive(false);
    }
}