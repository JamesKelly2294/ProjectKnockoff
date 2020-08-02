using UnityEngine;

public class PlayerTurnCompleteState : BaseTurnState
{
    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        // no-op since this is the end of the line.
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // no-op since this will be disabled immediately.
    }

    public override void OnEnterState(StateMachineManager manager)
    {
        base.OnEnterState(manager);
        manager.StopStateMachine();
    }
}