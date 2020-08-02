using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDraggingSpellState : BaseTurnState
{
    /// <summary>
    /// The BigBad. The final boss. 
    /// </summary>
    public BigBad bigBad;

    // TODO: Collect a list of all BigBad enemies here? Or let the next state deal with that?

    /// <summary>
    /// The idle state where the game waits for the player to take and complete an action.
    /// </summary>
    public BaseTurnState idleState;

    /// <summary>
    /// The state where the player is casting a spell against a monster, group of monsters, or the BigBad.
    /// </summary>
    public PlayerCastingState castingState;

    /// <summary>
    /// The state where the player is fusing a rune with a spell.
    /// </summary>
    public PlayerFusingState fusingState;

    /// <summary>
    /// The spell which is being dragged.
    /// </summary>
    private PlayerSpellCard spell;

    public void Configure(PlayerSpellCard spell)
    {
        this.spell = spell;
    }

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerFinishedDragOnUnspecified:
                // Abort the spell drag and go back to the idle state.
                AbortSpellDrag(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnBigBad:
                AttackBigBadWithSpell(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyAOE:
                AttackMonstersWithAOESpell(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyMonster:
                AttackMonsterWithSpell(manager);
                break;

            case StateMachineEventType.PlayerFinishedDragOnRune:
                FuseSpellWithRune(manager, context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnDiscardPile:
                DiscardSpell(manager, context);
                break;
        }
    }

    public override void OnEnterState(StateMachineManager manager)
    {
        base.OnEnterState(manager);

        // TODO: Figure out which things we can interact with here, maybe with a visual treatment.
    }

    public override void OnExitState(StateMachineManager manager, BaseTurnState nextState)
    {
        base.OnExitState(manager, nextState);

        // TODO: Undo any of the visual treatments from when the state was transitioned into.
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Anything here?
    }

    private void AbortSpellDrag(StateMachineManager manager)
    {
        // TODO: Any cleanup or animations required here?

        // Transition back to the idle state.
        manager.TransitionToState(idleState);
    }

    private void AttackBigBadWithSpell(StateMachineManager manager)
    {
        // TODO: Do any setup on the casting state prior to transitioning.

        // Transition to the casting state after setting it up.
        manager.TransitionToState(castingState);
    }

    private void AttackMonstersWithAOESpell(StateMachineManager manager)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.
        manager.TransitionToState(castingState);
    }

    private void AttackMonsterWithSpell(StateMachineManager manager)
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        manager.TransitionToState(castingState);
    }

    private void FuseSpellWithRune(StateMachineManager manager, StateMachineEventContext context)
    {
        if (context.HasRunes)
        {
            fusingState.Configure(spell, context.runes.First());
            manager.TransitionToState(fusingState);
        }
        else
        {
            Debug.Log("No Rune was provided to fuse with.");
        }
    }

    private void DiscardSpell(StateMachineManager manager, StateMachineEventContext context)
    {
        // TODO: Do whatever is needed to move the card to the discard pile.

        // Transition back to the idle state. We can discard as many spells as we have in the hand.
        manager.TransitionToState(idleState);
    }
}