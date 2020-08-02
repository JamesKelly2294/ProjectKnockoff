using UnityEngine;

/// <summary>
/// Possible events which can result in the state machine for the turn transitioning to the next state.
/// </summary>
public enum StateMachineEventType
{
    /// <summary>
    /// The player started their turn.
    /// </summary>
    PlayerTurnBegan,

    /// <summary>
    /// The player ended their turn.
    /// </summary>
    PlayerTurnEnded,

    /// <summary>
    /// The player finished drawing up to the hand limit.
    /// </summary>
    PlayerFinishedDrawingUpToHandLimit,

    /// <summary>
    /// The player activated a Mana.
    /// </summary>
    PlayerActivatedMana,

    /// <summary>
    /// The player deactivated a Mana.
    /// </summary>
    PlayerDeactivatedMana,

    /// <summary>
    /// The player began a drag event starting from a spell.
    /// </summary>
    PlayerBeganSpellDrag,

    /// <summary>
    /// The player began a drag event starting from a rune.
    /// </summary>
    PlayerBeganRuneDrag,

    /// <summary>
    /// The drag event ended on a specific monster controlled by the BigBad.
    /// </summary>
    PlayerFinishedDragOnEnemyMonster,

    /// <summary>
    /// The drag event ended in a way where an AOE attack should hit all (or a subset?) of the enemy's monsters.
    /// </summary>
    PlayerFinishedDragOnEnemyAOE,

    /// <summary>
    /// The drag event ended on the overall enemy.
    /// </summary>
    PlayerFinishedDragOnBigBad,

    /// <summary>
    /// The drag event ended on a rune.
    /// </summary>
    PlayerFinishedDragOnRune,

    /// <summary>
    /// The drag event ended on the discard pile.
    /// </summary>
    PlayerFinishedDragOnDiscardPile,

    /// <summary>
    /// The drag event ended on the board or some other unactionable entity.
    /// </summary>
    PlayerFinishedDragOnUnspecified,

    /// <summary>
    /// Any animations/logic/etc. for attacking an enemy monster are complete.
    /// </summary>
    PlayerFinishedCasting,

    /// <summary>
    /// Any animations/logic/etc. for fusing a rune to a card are complete.
    /// </summary>
    PlayerFinishedFusing,

    /// <summary>
    /// Any animations/logic/etc. for purchasing a rune are complete.
    /// </summary>
    PlayerFinishedPurchasing,
}