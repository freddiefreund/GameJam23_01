using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using static CharacterFighting;

class FightHandler : MonoBehaviour
{
    public UnityEvent<CharPosition> OnWinFight;

    [SerializeField] private CharacterFighting[] characters;

    private bool isFighting = true;

    private void Start()
    {
        DOTween.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            characters[1].gameObject.SetActive(true);
            characters[0].StartCoroutine("AttackLoop");
            characters[1].StartCoroutine("AttackLoop");
            characters[0].transform.DOMoveX(-3f, 0.5f).SetEase(Ease.OutCirc);
        }
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
            int winnerIndex = 1 - (int)defender;
            OnWinFight.Invoke((CharacterFighting.CharPosition)winnerIndex);
        }
    }
}
