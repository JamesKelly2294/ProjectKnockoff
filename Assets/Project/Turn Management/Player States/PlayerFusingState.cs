using UnityEngine;

public class PlayerFusingState : BaseTurnState
{
    /// <summary>
    /// The final state to navigate to once the fusion is complete.
    /// </summary>
    public BaseTurnState terminalState;

    /// <summary>
    /// The spell that the rune will be merged with.
    /// </summary>
    private PlayerSpellCard spell;

    /// <summary>
    /// The rune to merge with the spell.
    /// </summary>
    private GameRune rune;

    public void Configure(PlayerSpellCard spell, GameRune rune)
    {
        this.spell = spell;
        this.rune = rune;
    }

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        if (eventType == StateMachineEventType.PlayerFinishedFusing)
        {
            stateMachineManager.TransitionToState(terminalState);
        }
    }
}