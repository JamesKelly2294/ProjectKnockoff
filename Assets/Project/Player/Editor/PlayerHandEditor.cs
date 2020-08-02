using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerHand))]
public class PlayerHandEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerHand playerHand = (PlayerHand)target;
        GUILayout.Space(20);

        if (GUILayout.Button("Fill Hand"))
        {
            playerHand.FillHand();
        }

        if (GUILayout.Button("Draw Card"))
        {
            playerHand.DrawCard();
        }
    }
}
