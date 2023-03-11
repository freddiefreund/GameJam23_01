using Character;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCardArea : MonoBehaviour
{
    [SerializeField] private Transform startCardPosition;
    [SerializeField] private Vector3 placementOffset;
    [SerializeField] private Player player;
    
    private List<Card> _placedCards = new ();

    public bool PlaceCard(Card card)
    {
        card.transform.position = startCardPosition.position + placementOffset * _placedCards.Count;
        _placedCards.Add(card);
        player.AddPart(card.cardData.characterPart);
        card.Place();
        return true;
    }

    public void RemoveCard(Card card)
    {
        _placedCards.Remove(card);
        PositionCards();
        Destroy(card.gameObject);
    }

    private void PositionCards()
    {
        for (int i = 0; i < _placedCards.Count; i++)
        {
            _placedCards.ElementAt(i).transform.position = startCardPosition.position + placementOffset * i;
        }
    }
}
