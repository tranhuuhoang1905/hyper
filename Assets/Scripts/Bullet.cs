using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float Damage = 1f;
    float xSpeed;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        
        transform.localScale = new Vector2 ((Mathf.Sign(xSpeed)), 1f);
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag != "Player")
        {
            if(other.gameObject.tag == "Enemy")
            {
                // Destroy(other.gameObject);
                Enemy enemy =  other.gameObject.GetComponent<Enemy>();
                enemy.TakeDame(Damage);
            }
            Destroy(gameObject);
        }
    }

}
