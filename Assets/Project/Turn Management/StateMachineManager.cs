using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    /// <summary>
    /// The initial state to start the state machine with.
    /// </summary>
    public BaseTurnState startingState;

    /// <summary>
    ///  The current state. 
    /// </summary>
    public BaseTurnState currentState { get; private set; }

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Starting the TurnManager state machine");
        currentState = startingState;
        currentState.ConfigureTurnManager(this);
        currentState.OnEnterState(this);
    }

    public void StopStateMachine()
    {
        currentState.gameObject.SetActive(false);
        currentState = startingState;
    }

    /// <summary>
    /// Forcibly transition the state machine to the given state.
    /// </summary>
    /// <param name="nextState">The state that will be transition into</param>
    public void TransitionToState(BaseTurnState nextState)
    {
        currentState.OnExitState(this, nextState);
        currentState = nextState;
        currentState.ConfigureTurnManager(this);
        currentState.OnEnterState(this);
    }

    /// <summary>
    /// Handle events which may result in the state machine transitioning into another state.
    /// This delegates to the current state to handle the event.
    /// </summary>
    /// <param name="eventType">The type of event which occured</param>
    /// <param name="context">Additional context-specific data which is related to the event</param>
    public void HandleTurnManagerEvent(StateMachineEventType eventType, StateMachineEventContext context)
    {
        currentState.HandleTurnStateEvent(this, eventType, context);
    }
}

[CustomEditor(typeof(StateMachineManager))]
public class StateMachineDebugInspector : Editor
{
    public StateMachineEventType eventType;

    private PlayerSpellCard spell;
    private PlayerSpellCard mana;
    private GameRune rune;
    private Enemy enemy;

    private PlayerSpellCard[] spells;

    private bool showStateMachineDebugger = false;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StateMachineManager manager = (StateMachineManager)target;

        if (manager.currentState != null)
        {
            EditorGUILayout.Space();
            showStateMachineDebugger = EditorGUILayout.BeginFoldoutHeaderGroup(showStateMachineDebugger, "State Machine Debugger");
            
            if (showStateMachineDebugger)
            {
                EditorGUILayout.LabelField($"Current State: {manager.currentState.name}");
                eventType = (StateMachineEventType)EditorGUILayout.EnumPopup("State Machine Event Type: ", eventType);

                EditorGUILayout.LabelField("State Machine Event Context");
                spell = (PlayerSpellCard)EditorGUILayout.ObjectField("Spell: ", spell, typeof(PlayerSpellCard), true);
                mana = (PlayerSpellCard)EditorGUILayout.ObjectField("Mana: ", mana, typeof(PlayerSpellCard), true);
                rune = (GameRune)EditorGUILayout.ObjectField("Rune: ", rune, typeof(GameRune), true);
                enemy = (Enemy)EditorGUILayout.ObjectField("Enemy: ", enemy, typeof(Enemy), true);

                if (GUILayout.Button("Send Event"))
                {
                    var spells = new List<PlayerSpellCard>();
                    spells.Add(spell);

                    var runes = new List<GameRune>();
                    runes.Add(rune);

                    var enemies = new List<Enemy>();
                    enemies.Add(enemy);

                    var context = new StateMachineEventContext()
                    {
                        spells = spells,
                        mana = mana,
                        runes = runes,
                        enemies = enemies
                    };
                    manager.HandleTurnManagerEvent(eventType, context);
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
        }
    }
}