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
        descriptionElement.text = GetDescriptionFromPart(data.characterPart);
        backgroundElement.sprite = data.backgroundImage;
    }

    private string GetDescriptionFromPart(CharacterPart part)
    {
        if (part is CharacterHead)
        {
            return GetHeadDescription((CharacterHead)part);
        }
        if (part is CharacterBody)
        {
            return GetBodyDescription((CharacterBody)part);
        }
        if (part is CharacterArms)
        {
            return GetArmsDescription((CharacterArms)part);
        }
        if (part is CharacterWeapon)
        {
            return GetWeaponDescription((CharacterWeapon)part);
        }

        return "hmmmm";
    }

    private string GetHeadDescription(CharacterHead head)
    {
        return $"HP: {head.hp} \nHeadDef: {head.headDefense}";
    }

    private string GetBodyDescription(CharacterBody body)
    {
        return $"HP: {body.hp} \nBodyDef: {body.bodyDefense}";
    }
    
    private string GetArmsDescription(CharacterArms arms)
    {
        return $"Atk x{arms.attackBonus} \nSpeed x{arms.speedModifier}";
    }

    private string GetWeaponDescription(CharacterWeapon weapon)
    {
        var descr = $"Speed x{weapon.speedModifier}";
        if (weapon.attackValueBody > 0)
            descr += $"\nBody atk.: {weapon.attackValueBody}";
        if (weapon.attackValueHead > 0)
            descr += $"\nHead atk.: {weapon.attackValueHead}";
        
        return descr;
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
