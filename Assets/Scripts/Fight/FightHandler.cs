using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using static Character;

class FightHandler : MonoBehaviour
{
    public UnityEvent<CharPosition> OnWinFight;

    [SerializeField] private Character[] characters;

    private bool isFighting = true;

    private void Start()
    {
        DOTween.Init();
    }

    public void AttackCharacter(CharPosition attacker, float attackValue)
    {
        int targetIndex = 1 - (int)attacker;

        characters[targetIndex].ReceiveDamage(attackValue);
    }

    public void CheckForDeath(CharPosition defender, float health)
    {
        if (health <= 0)
        {
            int winnerIndex = 1 - (int)defender;
            OnWinFight.Invoke((CharPosition)winnerIndex);
        }
    }
}
