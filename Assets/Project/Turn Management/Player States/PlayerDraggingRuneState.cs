using System;
using UnityEngine;

public class PlayerDraggingRuneState : BaseTurnState
{
    /// <summary>
    /// The BigBad. The final boss. 
    /// </summary>
    public BigBad bigBad;

    /// <summary>
    /// The idle state where the game waits for the player to take and complete an action.
    /// </summary>
    public BaseTurnState idleState;

    /// <summary>
    /// The state where the player is casting a rune against a monster, group of monsters, or the BigBad.
    /// </summary>
    public PlayerCastingState castingState;

    /// <summary>
    /// The state where the player is purchasing the rune, which turns it into a usable card for later.
    /// </summary>
    public PlayerPurchasingState purchasingState;

    /// <summary>
    /// The Rune that is being dragged.
    /// </summary>
    private GameRune rune;

    public void Configure(GameRune rune)
    {
        this.rune = rune;
    }

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerFinishedDragOnUnspecified:
                AbortRuneDrag();
                break;

            case StateMachineEventType.PlayerFinishedDragOnBigBad:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackBigBadWithRune();
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyAOE:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackMonstersWithAOERune(context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyMonster:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackMonsterWithRune(context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnDiscardPile:
                PurchaseRune();
                break;
        }
    }

    private void AbortRuneDrag()
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition back to the idle state.
        stateMachineManager.TransitionToState(idleState);
    }

    private void AttackBigBadWithRune()
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        stateMachineManager.TransitionToState(castingState);
    }

    private void AttackMonstersWithAOERune(StateMachineEventContext context)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        stateMachineManager.TransitionToState(castingState);
    }

    private void AttackMonsterWithRune(StateMachineEventContext context)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        stateMachineManager.TransitionToState(castingState);
    }
    private void PurchaseRune()
    {
        purchasingState.Configure(rune);
        stateMachineManager.TransitionToState(purchasingState);
    }
}