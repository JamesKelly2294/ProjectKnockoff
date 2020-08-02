using UnityEngine;

public class PlayerTurnCompleteState : BaseTurnState
{
    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        // no-op since this is the end of the line.
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        stateMachineManager.StopStateMachine();
    }
}