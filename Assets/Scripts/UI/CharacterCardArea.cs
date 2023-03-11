using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterCardArea : MonoBehaviour
{
    [SerializeField] private Transform startCardPosition;
    [SerializeField] private Vector3 placementOffset;
    [SerializeField] private Character.Character character;
    [SerializeField] private Transform bottomCardAreaTransform;

    private int _numOfPlacedCards;
    private Card _placedBody;
    private Card _placedHead;
    private Card _placedArms;
    private Card _placedWeapon;

    public bool PlaceCard(Card card)
    {
        var cardPart = card.cardData.characterPart;
        
        if (cardPart is CharacterBody)
        {
            if (_placedBody != null)
            {
                _placedBody.GetComponent<Draggable>().enabled = true;
                _placedBody.transform.SetParent(bottomCardAreaTransform);
            }
            _placedBody = card;
        }
        else if (cardPart is CharacterHead)
        {
            if (_placedBody == null)
                return false;

            if (_placedHead != null)
            {
                _placedHead.GetComponent<Draggable>().enabled = true;
                _placedHead.transform.SetParent(bottomCardAreaTransform);
            }
            _placedHead = card;
        }
        else if (cardPart is CharacterArms)
        {
            if (_placedBody == null)
                return false;

            if (_placedArms != null)
            {
                _placedArms.GetComponent<Draggable>().enabled = true;
                _placedArms.transform.SetParent(bottomCardAreaTransform);
            }
            _placedArms = card;
        }
        else if (cardPart is CharacterWeapon)
        {
            if (_placedArms == null)
                return false;

            if (_placedWeapon != null)
            {
                _placedWeapon.GetComponent<Draggable>().enabled = true;
                _placedWeapon.transform.SetParent(bottomCardAreaTransform);
            }
            _placedWeapon = card;
        }
        
        card.transform.position = startCardPosition.position + placementOffset * _numOfPlacedCards;
        _numOfPlacedCards++;
        character.AddPart(card.cardData.characterPart);
        card.transform.SetParent(transform);
        card.Place();
        PositionCards();
        return true;
    }

    public void RemoveCard(Card card)
    {
        _numOfPlacedCards--;
        PositionCards();
        Destroy(card.gameObject);
    }

    private void PositionCards()
    {
        int placeId = 0;
        int currentSiblingIndex = 0;
        if (_placedHead != null)
        {
            _placedHead.transform.position = CalculateCardPosition(placeId);
            //_placedHead.transform.SetAsLastSibling();
            currentSiblingIndex = _placedHead.transform.GetSiblingIndex() + 1;
            placeId++;
        }

        if (_placedBody != null)
        {
            _placedBody.transform.position = CalculateCardPosition(placeId);
            if (currentSiblingIndex == 0)
                currentSiblingIndex = _placedBody.transform.GetSiblingIndex();
            _placedBody.transform.SetSiblingIndex(currentSiblingIndex++);
            placeId++;
        }

        if (_placedArms != null)
        {
            _placedArms.transform.position = CalculateCardPosition(placeId);
            _placedArms.transform.SetSiblingIndex(currentSiblingIndex++);
            placeId++;
        }

        if (_placedWeapon != null)
        {
            _placedWeapon.transform.position = CalculateCardPosition(placeId);
            _placedWeapon.transform.SetSiblingIndex(currentSiblingIndex);
        }
    }

    private Vector3 CalculateCardPosition(int placeId)
    {
        return startCardPosition.position + placementOffset * placeId;
    }
}
