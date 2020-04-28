using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;
    public SpriteRenderer sprite;
    private SoundController sound;
    void Update()
    {

        //schedulePlay(sound.mm_damage);
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
    /*public void schedulePlay(AudioClip sound)

    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }*/

}

