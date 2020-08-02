using UnityEngine;

public class PlayerCastingState : BaseTurnState
{
    /// <summary>
    /// The final state to navigate to once the spell or rune has been cast.
    /// </summary>
    public BaseTurnState terminalState;

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        if (eventType == StateMachineEventType.PlayerFinishedCasting)
        {
            manager.TransitionToState(terminalState);
        }
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Anything needed here?
    }
}
