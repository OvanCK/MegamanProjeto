using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamento : MonoBehaviour
{

    public Transform player;
    public float speed;
    public float distanciaAtk;
    public SpriteRenderer sprite;
    public Animator animator;


    public bool isMoving = false;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = PlayerDistance();
        transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);

        isMoving = (distance < distanciaAtk);
        if (isMoving){
            speed = 2.1f;
            animator.SetBool("Attack", true);

            if (player.position.x > transform.position.x && !sprite.flipX)         
            {
                 Flip();
            }
            if (player.position.x < transform.position.x && sprite.flipX)
            {
                Flip();
            }


        }
        if (isMoving == false)
        {
            speed = 0;
            animator.SetBool("Attack", false);

        }
    }

    public float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    public void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }

}
