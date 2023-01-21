using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterFighting : MonoBehaviour
{
    public enum CharPosition
    {
        LEFT = 0,
        RIGHT = 1
    }

    public UnityEvent<CharPosition, float> OnAttack;
    public UnityEvent<CharPosition, float> OnReceiveDamage;
    public UnityEvent<CharPosition, float> OnUpdateHealth;

    static float timeStep = 0.02f;

    [SerializeField] private CharPosition position;
    [SerializeField] private float attackValue;
    [SerializeField] private float defenseValue;
    [SerializeField] private float speedValue;

    private float currentHealth = 100;
    private float currentCooldown = 1.0f;

    private bool isFighting = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AttackLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator AttackLoop()
    {
        while(isFighting && currentHealth > 0) // and fight not finished
        {
            if (currentCooldown > 0)
            {
                currentCooldown = Mathf.Max(currentCooldown - timeStep, 0.0f);
            }
            else
            {
                Attack();
            }
            yield return new WaitForSeconds(timeStep);
        }
    }

    public void ReceiveDamage(float value)
    {
        float fullDamage = value / defenseValue;
        currentHealth = Mathf.Max(currentHealth - (fullDamage), 0.0f); // TODO: use proper defense formula

        OnUpdateHealth.Invoke(position, currentHealth);
        OnReceiveDamage.Invoke(position, fullDamage);
    }

    private void Attack()
    {
        OnAttack.Invoke(position, 10 * attackValue); // TODO: use proper attack formula 
        currentCooldown = 1.0f;

        //SFXPlayer.instance.PlaySound();
    }

    public void StopFighting()
    {
        isFighting = false;
    }
}
