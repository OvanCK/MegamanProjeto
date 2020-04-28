using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossVida : MonoBehaviour
{

    //public Camera camera;



    public int health = 3000;
    public GameObject deathEffect;
    public SpriteRenderer sprite;
    public Slider hp;

    private void Update()
    {
        hp.value = health;
    }

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine(Damage());

        if (health <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
