using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public UnityEvent<float> OnUpdateHealth;

    static float timeStep = 0.02f;

    [SerializeField] private float attackValue;
    [SerializeField] private float defenseValue;
    [SerializeField] private float speedValue;

    private float maxHealth;
    private float currentHealth;

    private float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 1.0f * speedValue;
        StartCoroutine("AttackLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator AttackLoop()
    {
        while(currentHealth > 0) // and fight not finished
        {
            if (currentCooldown > 0)
            {
                currentCooldown = Mathf.Max(currentCooldown - timeStep, 0.0f);
            }
            yield return new WaitForSeconds(timeStep);
        }
    }

    private void ReceiveDamage(float value)
    {
        currentHealth = Mathf.Max(currentHealth - value, 0.0f);

        OnUpdateHealth.Invoke(currentHealth);
    }

    private void Attack()
    {

    }
}
