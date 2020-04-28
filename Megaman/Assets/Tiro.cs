using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1.2f);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Enemy"))
        {
            Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
            if (enemy != null)
            {
                enemy.TakeDamage(40);
            }
            BossVida boss = hitInfo.GetComponent<BossVida>();
            if (boss != null)
            {
                boss.TakeDamage(40);
            }
            Destroy(gameObject);
        }
    }
}
