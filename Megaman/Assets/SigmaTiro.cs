using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigmaTiro : MonoBehaviour
{

    float velocidade = 7f;
    public Transform Target;
    Rigidbody2D rb;

    Vector2 moveDirection;

    private void Awake()
    {
        //Target = GameObject.Find("Target").GetComponent<Transform>();

    }

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindObjectOfType<MovPlayer>();
        Target = GameObject.Find("Target").GetComponent<Transform>();
        moveDirection = (Target.transform.position - transform.position).normalized * velocidade;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        VidaJogador vidaJogador = hitInfo.GetComponent<VidaJogador>();

        if (vidaJogador != null)
        {
           vidaJogador.TakeDamage(10);
        }
        Destroy(gameObject);


    }

}

