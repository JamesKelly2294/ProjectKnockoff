using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public GameObject basePlayerSpellCard;

    public Card MakePlayerCard(RuneTrait trait, RuneType type)
    {
        GameObject baseCard = Instantiate(basePlayerSpellCard);
        PlayerSpellCard card = baseCard.GetComponent<PlayerSpellCard>();
        card.MainSlot.RuneTrait = trait;
        card.MainSlot.RuneType = type;
        card.MainSlot.hasRune = true;
        return card;
    }
}
