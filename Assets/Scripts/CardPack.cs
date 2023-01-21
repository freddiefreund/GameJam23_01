using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform bottomCardArea;
    [SerializeField] private List<CardData> possibleCards;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int cardAmount;
    [SerializeField] private float spawnPause;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(OpenPack());
    }

    private IEnumerator OpenPack()
    {
        for (int i = 0; i < cardAmount; i++)
        {
            var card = Instantiate(cardPrefab, bottomCardArea);
            var randomCardIndex = Random.Range(0, possibleCards.Count);
            card.SetValues(possibleCards.ElementAt(randomCardIndex));
            yield return new WaitForSeconds(spawnPause);
        }
    }
}
