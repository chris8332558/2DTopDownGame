using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float aDamage)
    {
        currentHealth = Mathf.Clamp(currentHealth - aDamage, 0, maxHealth);
	}

    public void TakeHeal(float aHeal)
    {
        currentHealth = Mathf.Clamp(currentHealth + aHeal, 0, maxHealth);
	}
}
