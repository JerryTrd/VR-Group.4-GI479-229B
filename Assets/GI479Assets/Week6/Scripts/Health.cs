using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    public UnityEvent OnTakeDamage;
    public UnityEvent OnDead;

    public float currentHealth;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamhege(float damageAmount)
    {
        if (!IsDead())
        {
            OnTakeDamage.Invoke();
            currentHealth -= damageAmount;
            print($"{currentHealth}");

            if(IsDead())
            {
                OnDead?.Invoke();
            }

        }
    }
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    
}
