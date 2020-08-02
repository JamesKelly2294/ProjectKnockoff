using System.Collections.Generic;
using UnityEngine;

public class StateMachineEventContext
{
    /// <summary>
    /// Populated when the event involves one or more spells.
    /// </summary>
    public ICollection<PlayerSpellCard> spells;

    /// <summary>
    /// Populated when 
    /// </summary>
    public PlayerSpellCard mana;

    /// <summary>
    /// Populated when the event involves one or more runes.
    /// </summary>
    public ICollection<GameRune> runes;

    /// <summary>
    /// Populated when the event involves one or more enemies.
    /// </summary>
    public ICollection<Enemy> enemies;

    public bool HasCastableSpell
    {
        // TODO: exclude mana from this check.
        get { return spells != null && spells.Count > 0; }
    }

    public bool HasTargetableEnemy
    {
        get { return enemies != null && enemies.Count > 0; }
    }

    public bool HasMana
    {
        get { return mana != null; }
    }

    public bool HasRunes
    {
        get { return runes != null && runes.Count > 0; }
    }
}
