using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth;
    public bool disableInsteadOfDestroy = false;
    public bool hasDeathAnimation;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        if (hasDeathAnimation)
        {
            animator = GetComponent<Animator>();
        }
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0.01)
        {
            Die();
        }
    }

    public void TakeHeal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    protected virtual void Die()
    {
        currentHealth = 0;
        if (hasDeathAnimation)
        {
            animator.SetTrigger("Death");
            if (disableInsteadOfDestroy)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
        else
        {
            if (disableInsteadOfDestroy)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

 
}
