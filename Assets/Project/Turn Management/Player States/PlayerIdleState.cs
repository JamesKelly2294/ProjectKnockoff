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

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerActivatedMana:
                ManaWasActivated(context);
                break;

            case StateMachineEventType.PlayerDeactivatedMana:
                ManaWasDeactivated(context);
                break;

            case StateMachineEventType.PlayerTurnEnded:
                PlayerTurnEnded();
                break;

            case StateMachineEventType.PlayerBeganSpellDrag:
                PlayerBeganSpellDrag(context);
                break;

            case StateMachineEventType.PlayerBeganRuneDrag:
                PlayerBeganRuneDrag(context);
                break;
        }
    }

    private void ManaWasActivated(StateMachineEventContext context)
    {
        if (context.HasMana)
        {
            // TODO: Do the thing with the mana.
            Debug.Log("Activating mana");
        }
        else
        {
            Debug.Log("No mana to use!");
        }
    }

    private void ManaWasDeactivated(StateMachineEventContext context)
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

    private void PlayerTurnEnded()
    {
        stateMachineManager.TransitionToState(terminalState);
    }

    private void PlayerBeganSpellDrag(StateMachineEventContext context)
    {
        if (context.HasCastableSpell)
        {
            // TODO: Any validation require before accepting the drag as valid? Or should that happen in the state?
            playerSpellDraggingState.Configure(context.spells.First());
            stateMachineManager.TransitionToState(playerSpellDraggingState);
        }
        else
        {
            Debug.Log("A spell was not specified!");
        }
    }

    private void PlayerBeganRuneDrag(StateMachineEventContext context)
    {
        if (context.HasRunes)
        {
            // TODO: Any validation require before accepting the drag as valid? Or should that happen in the state?
            playerRuneDraggingState.Configure(context.runes.First());
            stateMachineManager.TransitionToState(playerRuneDraggingState);
        }
        else
        {
            Debug.Log("A rune was not specified!");
        }
    }
}