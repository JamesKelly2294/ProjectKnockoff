using UnityEngine;

public class PlayerDrawingCardsState : BaseTurnState
{
    public BaseTurnState nextState;

    public override void HandleTurnStateEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        if (StateMachineEventType.PlayerFinishedDrawingUpToHandLimit == eventType)
        {
            stateMachineManager.TransitionToState(nextState);
        }
    }
}