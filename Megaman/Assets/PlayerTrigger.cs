using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private VidaJogador player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<VidaJogador>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!player.invunerable)
            {
                player.TakeDamage(15);
            }

            if (other.CompareTag("Spike"))
            {
                if (!player.invunerable || player.invunerable)
                {
                    player.TakeDamage(101);
                }
            }
        }
    }
}
