using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character.Character;

public class FightUIHandler : MonoBehaviour
{
    [SerializeField] Vector3[] textOffsetPositions;

    [SerializeField] GameObject damageTextPrefab;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] lifeBars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifeBar(CharacterFighting.CharPosition position, float value)
    {
        lifeBars[(int)position].transform.DOScaleX(value * 3 / 100, 0.2f);
    }

    public void SpawnDamageText(CharacterFighting.CharPosition position, float value)
    {
        GameObject instance = Instantiate(damageTextPrefab, canvas.transform);
        instance.transform.localPosition = textOffsetPositions[(int)position];
        instance.GetComponent<DamageText>().SetText($"{(int)value}");
    }
}
