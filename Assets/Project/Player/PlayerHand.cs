using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public int Capacity = 5;
    public List<Card> Cards;
    public PlayerDeck Deck;
    public float DistanceBetweenCards = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<Card>(Capacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillHand()
    {
        int cardsToDraw = Capacity - Cards.Count;
        for (int i = 0; i < cardsToDraw; i++)
        {
            DrawCard();
        }
    }


    public void DrawCard()
    {
        if(Cards.Count >= Capacity) { return; }

        Card card = Deck.DrawCard();
        card.transform.parent = transform;
        card.SetHidden(false);
        Cards.Add(card);

        const float distanceBetweenCards = 0.065f;
        float handWidth = (Cards.Count - 1) * distanceBetweenCards;
        for (int i = 0; i < Cards.Count; i++)
        {
            Card c = Cards[i];
            var moveAnimation = c.gameObject.GetComponent<TranslateAndRotateToPosition>();
            if (!moveAnimation)
            {
                moveAnimation = c.gameObject.AddComponent<TranslateAndRotateToPosition>();
            }
            moveAnimation.duration = 0.25f;

            moveAnimation.startPosition = c.transform.position;
            moveAnimation.startRotation = c.transform.rotation;
            
            Vector3 localTargetPosition = new Vector3(-handWidth/2.0f + (i * distanceBetweenCards), 0, 0);
            moveAnimation.endPosition = transform.TransformPoint(localTargetPosition);
            moveAnimation.endRotation = transform.rotation;
        }
    }
}
