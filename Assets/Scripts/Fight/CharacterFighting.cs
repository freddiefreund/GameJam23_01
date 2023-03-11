using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterFighting : MonoBehaviour
{
    public enum CharPosition
    {
        Left = 0,
        Right = 1
    }

    public enum CharTargetPart
    {
        Head = 0,
        Body = 1
    }

    public UnityEvent<CharPosition, CharTargetPart, float> OnAttack;
    public UnityEvent<CharPosition, float> OnReceiveDamage;
    public UnityEvent<CharPosition, float> OnUpdateHealth;

    static float timeStep = 0.02f;

    [SerializeField] private CharPosition _position;
    

    private float currentHealth = 100;
    private float currentCooldown = 1.0f;

    private bool isFighting = true;
    private Character.Character _character;

    private void Start()
    {
        _character = GetComponent<Character.Character>();
    }


    public IEnumerator AttackLoop()
    {
        currentCooldown = 1.0f / _character.Speed;
        while (isFighting && currentHealth > 0)
        {
            yield return new WaitForSeconds(currentCooldown);
            Attack();
        }
    }

    public void ReceiveDamage(float rawDamage, CharTargetPart targetPart)
    {
        float defense = targetPart == CharTargetPart.Head ? _character.HeadDefense : _character.BodyDefense;
        float trueDamage = rawDamage / defense;
        currentHealth = Mathf.Max(currentHealth - (trueDamage), 0.0f);

        OnUpdateHealth.Invoke(_position, currentHealth);
        OnReceiveDamage.Invoke(_position, trueDamage);
    }

    private void Attack()
    {
        OnAttack.Invoke(_position, CharTargetPart.Head, _character.AttackHead);
        OnAttack.Invoke(_position, CharTargetPart.Body, _character.AttackBody);
        currentCooldown = 1.0f / _character.Speed;
        
        SFXPlayer.instance.PlaySound(_character.WeaponSound);
    }

    public void StopFighting()
    {
        isFighting = false;
    }
}
