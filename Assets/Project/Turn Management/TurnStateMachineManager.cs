using UnityEditor.UI;
using UnityEngine;

/// <summary>
/// Possible events which can result in the state machine for the turn transitioning to the next state.
/// </summary>
public enum TurnStateMachineManagerEventType
{
    /// <summary>
    /// The player started their turn.
    /// </summary>
    PlayerBeginTurn,

    /// <summary>
    /// The player ended their turn.
    /// </summary>
    PlayerEndTurn,

    /// <summary>
    /// The player activated a Mana.
    /// </summary>
    PlayerManaActivated,

    /// <summary>
    /// The player deactivated a Mana.
    /// </summary>
    PlayerManaDeactivated,

    /// <summary>
    /// The player began a drag event starting from a spell.
    /// </summary>
    PlayerBeginSpellDrag,

    /// <summary>
    /// The player began a drag event starting from a rune.
    /// </summary>
    PlayerBeginRuneDrag,

    /// <summary>
    /// The drag event ended on a specific monster controlled by the BigBad.
    /// </summary>
    PlayerEndDragOnEnemyMonster,

    /// <summary>
    /// The drag event ended in a way where an AOE attack should hit all (or a subset?) of the enemy's monsters.
    /// </summary>
    PlayerEndDragOnEnemyAOE, 

    /// <summary>
    /// The drag event ended on the overall enemy.
    /// </summary>
    PlayerEndDragOnBigBad,

    /// <summary>
    /// The drag event ended on a rune.
    /// </summary>
    PlayerEndDragOnRune,

    /// <summary>
    /// The drag event ended on the discard pile.
    /// </summary>
    PlayerEndDragOnDiscard,

    /// <summary>
    /// The drag event ended on the board or some other unactionable entity.
    /// </summary>
    PlayerEndDragUnspecified,
}

public class TurnStateMachineManager : MonoBehaviour
{
    /// <summary>
    /// The initial state to start the state machine with.
    /// </summary>
    public BaseTurnState startingState;

    /// <summary>
    ///  The current state. 
    /// </summary>
    private BaseTurnState currentState;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Starting the TurnManager state machine");
        currentState = startingState;
        currentState.ConfigureTurnManager(this);
        currentState.OnTransitionIntoTurnState(this);
        currentState.Start();
    }

    // Update is called once per frame
    public void Update()
    {
        // TODO: Should TurnManager handle Player <-> Enemy turn logic on its own, or should that be another state machine?

        // TODO: Handle terminal state logic here?
    }

    /// <summary>
    /// Forcibly transition the state machine to the given state.
    /// </summary>
    /// <param name="nextState">The state that will be transition into</param>
    public void TransitionToState(BaseTurnState nextState)
    {
        currentState.OnTransitionFromTurnState(this, nextState);
        currentState = nextState;
        currentState.ConfigureTurnManager(this);
        currentState.OnTransitionIntoTurnState(this);
    }

    /// <summary>
    /// Handle events which may result in the state machine transitioning into another state.
    /// This delegates to the current state to handle the event.
    /// </summary>
    /// <param name="eventType">The type of event which occured</param>
    public void HandleTurnManagerEvent(TurnStateMachineManagerEventType eventType)
    {
        currentState.HandleTurnStateEvent(this, eventType);
    }
}