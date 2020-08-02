using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public GameObject baseCardPrefab;

    public Card MakeCard(RuneTrait trait, RuneType type)
    {
        GameObject baseCard = Instantiate(baseCardPrefab);
        Card card = baseCard.GetComponent<Card>();
        card.SetHidden(true);
        card.MainSlot.RuneTrait = trait;
        card.MainSlot.RuneType = type;
        card.MainSlot.hasRune = true;
        return card;
    }
}
