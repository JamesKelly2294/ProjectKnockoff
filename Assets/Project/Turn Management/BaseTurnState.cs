using UnityEngine;

public abstract class BaseTurnState : MonoBehaviour
{
    /// <summary>
    /// The State Machine which manages this state.
    /// </summary>
    private TurnStateMachineManager stateMachineManager;

    /// <summary>
    /// Handle any incoming events which may result in the state transitioning or require some kind of response.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    /// <param name="eventType">The event which occured</param>
    /// <param name="context">The GameObject which triggered the event (e.g. a Rune, Spell, etc.)</param>
    public abstract void HandleTurnStateEvent(TurnStateMachineManager manager, TurnStateMachineManagerEventType eventType, GameObject context);

    /// <summary>
    /// States in the State Machine should implement this instead of Update so they can have access to the turn manager.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    public abstract void OnUpdate(TurnStateMachineManager manager);

    /// <summary>
    /// Called on the current state when a transition to the next state is about to occur.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    /// <param name="nextState">The next state that the state machine will transition to</param>
    public virtual void OnTransitionFromTurnState(TurnStateMachineManager manager, BaseTurnState nextState)
    {
        Debug.Log($"Transitioning away from {this.name}.");
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Gives the next state that will be transitioned to an opportunity to perform any required setup.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state belongs to</param>
    public virtual void OnTransitionIntoTurnState(TurnStateMachineManager manager)
    {
        Debug.Log($"Transitioning into {this.name}.");
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Pass in a state machine which will manage this state's lifecycle.
    /// 
    /// You *probably* don't want to use this unless you know what you're doing
    /// or have some need for passing a state between state machines.
    /// </summary>
    /// <param name="manager">The state machine manager instance that this state will belong to</param>
    public void ConfigureTurnManager(TurnStateMachineManager manager)
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

    public void Start()
    {
        // Is this really useful?
        Debug.Log($"Starting {gameObject.name}.");
    }

    public void Update()
    {
        // Injects the state machine manager into the concrete state implementation.
        // This could be an explicit field on the base type, but I don't think
        // we want to introduce the possibility of miswiring state machines
        // if we get to a point where we're nesting them inside of states.
        OnUpdate(this.stateMachineManager);
    }
}