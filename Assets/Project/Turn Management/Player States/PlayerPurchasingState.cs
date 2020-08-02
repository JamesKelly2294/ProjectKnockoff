using UnityEngine;

public class PlayerPurchasingState : BaseTurnState
{
    /// <summary>
    /// The rune to purchase.
    /// </summary>
    private GameRune rune;

    /// <summary>
    /// The final state to navigate to once the purchase is complete.
    /// </summary>
    public BaseTurnState terminalState;

    public void Configure(GameRune rune)
    {
        this.rune = rune;
    }

    public override void HandleTurnStateEvent(StateMachineManager manager, StateMachineEventType eventType, StateMachineEventContext context)
    {
        if (eventType == StateMachineEventType.PlayerFinishedPurchasing)
        {
            manager.TransitionToState(terminalState);
        }
    }

    public override void OnEnterState(StateMachineManager manager)
    {
        base.OnEnterState(manager);
        
        // TODO: Orchestrate purchasing the rune here.
    }

    public override void OnUpdate(StateMachineManager manager)
    {
        // TODO: Is this needed?
    }
}