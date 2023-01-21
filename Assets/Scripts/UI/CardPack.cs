using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class CardPack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform bottomCardArea;
    [SerializeField] private List<CardData> possibleCards;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int cardAmount;
    [SerializeField] private float spawnPause;
    [SerializeField] private AudioClip cardSound1;
    [SerializeField] private AudioClip cardSound2;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
            _audioSource.clip = Random.Range(0, 2) > 0 ? cardSound1 : cardSound2;
            _audioSource.Play();
            yield return new WaitForSeconds(spawnPause);
        }
    }
}
