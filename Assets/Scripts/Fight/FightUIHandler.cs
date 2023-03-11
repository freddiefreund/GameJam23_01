using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Character.Character;
using static CharacterFighting;

public class FightUIHandler : MonoBehaviour
{
    [SerializeField] Vector3[] textOffsetPositions;

    [SerializeField] GameObject damageTextPrefab;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] lifeBars;
    [SerializeField] TextMeshPro[] lifeBarTexts;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void UpdateLifeBar(CharPosition position, float value)
    {
        lifeBars[(int)position].transform.DOScaleX(value * 8 / 100, 0.2f);
        lifeBarTexts[(int)position].text = ((int)value).ToString();
    }

    public void SpawnDamageText(CharPosition position, CharTargetPart targetPart, float value)
    {
        GameObject instance = Instantiate(damageTextPrefab, canvas.transform);
        instance.transform.localPosition = textOffsetPositions[(int)position];

        string bodyPart;
        if (targetPart == CharTargetPart.Body)
        {
            bodyPart = "Body";
            instance.transform.localPosition += new Vector3(0, 60, 0);
        } 
        else
        {
            bodyPart = "Head";
        }
        instance.GetComponent<DamageText>().SetText($"{bodyPart} {(int)value}");
    }
}
