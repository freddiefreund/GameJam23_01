using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.VirtualTexturing;
using static CharacterFighting;

class FightHandler : MonoBehaviour
{
    public UnityEvent<CharPosition> OnWinFight;

    [SerializeField] private CharacterFighting[] characters;

    private bool _isFighting = true;
    private int _enemyCounter = 1;

    private void Start()
    {
        DOTween.Init();
    }

    private void OnEnable()
    {
        OnWinFight.AddListener(HandleFightEnd);
    }

    private void OnDisable()
    {
        OnWinFight.RemoveListener(HandleFightEnd);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SetLevelToFight();
        }
    }

    private void SetLevelToFight()
    {
        _isFighting = true;
        characters[_enemyCounter].gameObject.SetActive(true);
        characters[0].StartCoroutine("AttackLoop");
        characters[_enemyCounter].StartCoroutine("AttackLoop");
        characters[0].transform.DOMoveX(-3f, 0.5f).SetEase(Ease.OutCirc);
    }

    private void HandleFightEnd(CharPosition character)
    {
        if(!_isFighting)
            return;

        _isFighting = false;
        if ((int)character == 0)
        {
            Debug.Log("Player won");
            SetLevelToPreparation();
        }
        else
        {
            Debug.Log("Enemy won!");
        }
    }

    private void SetLevelToPreparation()
    {
        _enemyCounter++;
        characters[1].gameObject.SetActive(false);
        characters[0].transform.DOMoveX(0, 0.5f).SetEase(Ease.OutCirc);
    }

    public void AttackCharacter(CharacterFighting.CharPosition attacker, CharTargetPart targetPart, float attackValue)
    {
        int targetIndex = 1 - (int)attacker;

        characters[targetIndex].ReceiveDamage(attackValue, targetPart);
    }

    public void CheckForDeath(CharacterFighting.CharPosition defender, float health)
    {
        if (health <= 0)
        {
            int winnerIndex = (int)defender == 0 ? 1 : 0;
            OnWinFight.Invoke((CharacterFighting.CharPosition)winnerIndex);
        }
    }
}
