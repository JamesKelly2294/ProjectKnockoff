using UnityEngine;

public class PlayerDrawingCardsState : BaseTurnState
{
    public BaseTurnState nextState;

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        if (StateMachineEventType.PlayerFinishedDrawingUpToHandLimit == eventType)
        {
            manager.TransitionToState(nextState);
        }
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Drive animation/movement stuff from here?
    }
}