using UnityEngine;

public class PlayerTurnIdleState : BaseTurnState
{
    public BaseTurnState playerSpellDraggingState;

    public BaseTurnState playerRuneDraggingState;

    public override void HandleTurnStateEvent(TurnStateMachineManager manager, TurnStateMachineManagerEventType eventType, GameObject context)
    {
        switch (eventType)
        {
            case TurnStateMachineManagerEventType.PlayerManaActivated:
                ManaWasActivated(context);
                break;
            case TurnStateMachineManagerEventType.PlayerManaDeactivated:
                // TODO: Validate that this is possible first?
                ManaWasDeactivated(context);
                break;
            case TurnStateMachineManagerEventType.PlayerEndTurn:
                PlayerTurnEnded();
                break;
            case TurnStateMachineManagerEventType.PlayerBeginSpellDrag:
                PlayerBeganSpellDrag(manager, context);
                break;
            case TurnStateMachineManagerEventType.PlayerBeginRuneDrag:
                PlayerBeganRuneDrag(manager, context);
                break;
            default:
                // Don't care about other events from here.
                break;
        }
    }

    public override void OnUpdate(TurnStateMachineManager manager)
    {
        // TODO: Anything needed here?
    }

    private void ManaWasActivated(GameObject mana)
    {
        // TODO: Handle the Mana being activated.
    }

    private void ManaWasDeactivated(GameObject mana)
    {
        // TODO: Handle the Mana being deactivated.
    }

    private void PlayerTurnEnded()
    {
        // TODO: Handle the player ending their turn/doing nothing.
    }

    private void PlayerBeganSpellDrag(TurnStateMachineManager manager, GameObject spell)
    {
        // TODO: Transition to the "Player is dragging the spell" state.
    }

    private void PlayerBeganRuneDrag(TurnStateMachineManager manager, GameObject rune)
    {
        // TODO: Any validation require before accepting the drag as valid? Or should that happen in the state?
        // TODO: Transition to the "Player is dragging a rune" state.
    }
}