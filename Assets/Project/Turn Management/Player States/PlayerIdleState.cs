using System.Linq;
using UnityEngine;

public class PlayerIdleState : BaseTurnState
{
    /// <summary>
    /// The state that the player enters when their turn is over.
    /// </summary>
    public BaseTurnState terminalState;

    /// <summary>
    /// The state the player enters when they begin to drag a spell.
    /// </summary>
    public PlayerDraggingSpellState playerSpellDraggingState;

    /// <summary>
    /// The state the player enters when they begin to drag a rune.
    /// </summary>
    public PlayerDraggingRuneState playerRuneDraggingState;

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerActivatedMana:
                ManaWasActivated(manager, context);
                break;

            case StateMachineEventType.PlayerDeactivatedMana:
                ManaWasDeactivated(manager, context);
                break;

            case StateMachineEventType.PlayerTurnEnded:
                PlayerTurnEnded(manager);
                break;

            case StateMachineEventType.PlayerBeganSpellDrag:
                PlayerBeganSpellDrag(manager, context);
                break;

            case StateMachineEventType.PlayerBeganRuneDrag:
                PlayerBeganRuneDrag(manager, context);
                break;

            default:
                // Don't care about other events from here.
                break;
        }
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Anything needed here?
    }

    private void ManaWasActivated(StateMachineManager manager, StateMachineEventContext context)
    {
        if (context.HasMana)
        {
            Debug.Log("Activating mana");
        }
        else
        {
            Debug.Log("No mana to use!");
        }
    }

    private void ManaWasDeactivated(StateMachineManager manager, StateMachineEventContext context)
    {
        if (context.HasMana)
        {
            // TODO: Do the thing with the mana.
            Debug.Log("Activating mana");
        }
        else
        {
            Debug.Log("No mana to deactivate!");
        }
    }

    private void PlayerTurnEnded(StateMachineManager manager)
    {
        manager.TransitionToState(terminalState);
    }

    private void PlayerBeganSpellDrag(StateMachineManager manager, StateMachineEventContext context)
    {
        if (context.HasCastableSpell)
        {
            playerSpellDraggingState.Configure(context.spells.First());
            manager.TransitionToState(playerSpellDraggingState);
        }
        else
        {
            Debug.Log("A spell was not specified");
        }
    }

    private void PlayerBeganRuneDrag(StateMachineManager manager, StateMachineEventContext context)
    {
        if (context.HasRunes)
        {
            // TODO: Any validation require before accepting the drag as valid? Or should that happen in the state?
            manager.TransitionToState(playerRuneDraggingState);
        }
    }
}