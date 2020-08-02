using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRuneSlot : MonoBehaviour, IHideable
{

    public GameRune GameRunePrefab;
    private GameRune gameRune;
    public GameObject mountLocation;

    public bool hasRune;
    public RuneTrait RuneTrait;
    public RuneType RuneType;

    // Start is called before the first frame update
    void Awake()
    {
        if (hasRune)
        {
            SpawnRune();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRune == null && hasRune)
        {
            SpawnRune();
        }
        else if (gameRune != null && !hasRune)
        {
            Destroy(gameRune.gameObject);
            gameRune = null;
        }
        else
        {
            UpdateRune();
        }
    }

    void SpawnRune()
    {
        gameRune = Instantiate(GameRunePrefab, mountLocation.transform);
        gameRune.SetHidden(_hidden); // there's got to be a better way
        UpdateRune();
    }

    void UpdateRune()
    {
        if (gameRune != null)
        {
            gameRune.RuneTrait = RuneTrait;
            gameRune.RuneType = RuneType;
        }
    }
    
    public string DebugString() {
        if (gameRune != null) {
            return gameRune.RuneName;
        } else {
            return "Empty";
        }
    }

    #region IHideable

    private bool _hidden;
    public void SetHidden(bool value)
    {
        _hidden = value;
        if (gameRune) { gameRune.SetHidden(value); };
    }

    #endregion
}
