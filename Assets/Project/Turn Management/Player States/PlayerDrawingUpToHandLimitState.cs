using UnityEngine;

public class PlayerDrawingUpToHandLimitState : BaseTurnState
{
    public BaseTurnState nextState;

    public override void HandleTurnStateEvent(TurnStateMachineManager manager, TurnStateMachineManagerEventType eventType, GameObject context)
    {
        if (TurnStateMachineManagerEventType.PlayerFinishedDrawingUpToHandLimit == eventType)
        {
            manager.TransitionToState(nextState);
        }
    }

    public override void OnUpdate(TurnStateMachineManager manager)
    {
        // TODO: Drive animation/movement stuff from here?
    }
}