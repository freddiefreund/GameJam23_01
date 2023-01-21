using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI titleElement;
    [SerializeField] private Image imageElement;
    [SerializeField] private TextMeshProUGUI descriptionElement;
    [SerializeField] private Image backgroundElement;

    public CardData cardData;
    private bool _isPlaced;

    public void SetValues(CardData data)
    {
        cardData = data;
        titleElement.text = data.titleText;
        imageElement.sprite = data.cardImage;
        descriptionElement.text = data.descriptionText;
        backgroundElement.sprite = data.backgroundImage;
    }

    public void Place()
    {
        _isPlaced = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isPlaced)
            return;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var characterCardArea = GetComponentInParent<CharacterCardArea>();
            characterCardArea.RemoveCard(this);
        }
    }
}
