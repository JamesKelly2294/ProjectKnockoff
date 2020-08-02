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

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        switch (eventType)
        {
            case StateMachineEventType.PlayerFinishedDragOnUnspecified:
                // Abort the spell drag and go back to the idle state.
                AbortSpellDrag();
                break;

            case StateMachineEventType.PlayerFinishedDragOnBigBad:
                AttackBigBadWithSpell();
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyAOE:
                AttackMonstersWithAOESpell();
                break;

            case StateMachineEventType.PlayerFinishedDragOnEnemyMonster:
                AttackMonsterWithSpell();
                break;

            case StateMachineEventType.PlayerFinishedDragOnRune:
                FuseSpellWithRune(context);
                break;

            case StateMachineEventType.PlayerFinishedDragOnDiscardPile:
                DiscardSpell(context);
                break;
        }
    }

    public override void OnEnterState()
    {
        base.OnEnterState();

        // TODO: Figure out which things we can interact with here, maybe with a visual treatment.
    }

    public override void OnExitState(BaseTurnState nextState)
    {
        base.OnExitState(nextState);

        // TODO: Undo any of the visual treatments from when the state was transitioned into.
    }

    private void AbortSpellDrag()
    {
        // TODO: Any cleanup or animations required here?

        // Transition back to the idle state.
        stateMachineManager.TransitionToState(idleState);
    }

    private void AttackBigBadWithSpell()
    {
        // TODO: Do any setup on the casting state prior to transitioning.

        // Transition to the casting state after setting it up.
        stateMachineManager.TransitionToState(castingState);
    }

    private void AttackMonstersWithAOESpell()
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.
        stateMachineManager.TransitionToState(castingState);
    }

    private void AttackMonsterWithSpell()
    {
        // TODO: perform any initialization/setup on the casting state before transitioning to it.

        // Transition to the casting state after setting it up.
        stateMachineManager.TransitionToState(castingState);
    }

    private void FuseSpellWithRune(StateMachineEventContext context)
    {
        if (context.HasRunes)
        {
            fusingState.Configure(spell, context.runes.First());
            stateMachineManager.TransitionToState(fusingState);
        }
        else
        {
            Debug.Log("No Rune was provided to fuse with.");
        }
    }

    private void DiscardSpell(StateMachineEventContext context)
    {
        // TODO: Do whatever is needed to move the card to the discard pile.

        // Transition back to the idle state. We can discard as many spells as we have in the hand.
        stateMachineManager.TransitionToState(idleState);
    }
}