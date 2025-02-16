using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] int score = 1;
    [SerializeField] Headbar healthBar;
    // Start is called before the first frame update
    private void Awake()
    {
        healthBar = GetComponentInChildren<Headbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDame (float damageAmount)
    {
        health -=damageAmount;
        
        Debug.Log("Object health: " + health);
        Debug.Log("Object maxHealth: " + maxHealth);
        healthBar.UpdateHealthBar(health,maxHealth);
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(score);
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
