using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);

    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        VidaJogador vidaJogador = hitInfo.GetComponent<VidaJogador>();

        if (vidaJogador != null)
        {
            vidaJogador.TakeDamage(10);
        }


    }
}
