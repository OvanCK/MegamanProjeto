using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 
public class VidaJogador : MonoBehaviour
{
    public int health = 100;
    public Slider BarradeVida;
    public bool invunerable = false;
    public SpriteRenderer sprite;
    private SoundController sound;
    public GameObject deathEffect;




    public void TakeDamage(int damage)
    {
        health -= damage;

        BarradeVida.value = health;
        invunerable = true;
        StartCoroutine(Damage());

        if (health <= 0)
        {
            Die();
        }
        if (health > 100)
        {
            health = 100;
        }
    }


    private void Update()
    {
        BarradeVida.value = health;

    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
       
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    IEnumerator Damage()
    {
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }

        invunerable = false;
    }
    public void schedulePlay(AudioClip sound)

    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }



}
