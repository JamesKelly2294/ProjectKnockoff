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

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerFinishedDragOnUnspecified:
                AbortRuneDrag(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnBigBad:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackBigBadWithRune(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyAOE:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackMonstersWithAOERune(manager, context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyMonster:
                // TODO: Would it be possible to convert the rune into a spell and use the same logic in PlayerCastingState for both Runes and Spells?
                AttackMonsterWithRune(manager, context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnDiscardPile:
                PurchaseRune(manager);
                break;
        }
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Anything here?
    }

    private void AbortRuneDrag(StateMachineManager manager)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition back to the idle state.
        manager.TransitionToState(idleState);
    }

    private void AttackBigBadWithRune(StateMachineManager manager)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        manager.TransitionToState(castingState);
    }

    private void AttackMonstersWithAOERune(StateMachineManager manager, StateMachineEventContext context)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        manager.TransitionToState(castingState);
    }

    private void AttackMonsterWithRune(StateMachineManager manager, StateMachineEventContext context)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        manager.TransitionToState(castingState);
    }
    private void PurchaseRune(StateMachineManager manager)
    {
        purchasingState.Configure(rune);
        manager.TransitionToState(purchasingState);
    }
}