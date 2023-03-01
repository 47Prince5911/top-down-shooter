using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static event Action<EnemyScript> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void Start()
    {
        health = maxHealth;
    }




    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount:  {damageAmount}");
        health -= damageAmount;
        Debug.Log($"health is now:  {health}");

        if(health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

}
