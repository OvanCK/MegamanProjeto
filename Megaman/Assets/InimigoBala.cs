using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBala : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        VidaJogador vidaJogador = hitInfo.GetComponent<VidaJogador>();
        //Player enemy = 
        if (vidaJogador != null)
        {
            vidaJogador.TakeDamage(20);
        }
        Destroy(gameObject);


    }
}

