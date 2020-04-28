using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistola : MonoBehaviour
{

    public Transform player;
    public Transform FirePoint;
    public float firerate = 0.5f;
    public float Atirar = 0;
    public Animator animator;
    public GameObject balaPrefab;
    private bool onRange = false;
    public SpriteRenderer sprite;
    private bool m_FacingRight = true;


    public float range = 5;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

    }
    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;


        if (player.position.x < transform.position.x && !m_FacingRight)
        {
            Flip();
        }
        if (player.position.x > transform.position.x && m_FacingRight)
        {
            Flip();
        }

        if (onRange)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.0000000000001f);


            Shoot();
        }
        }
    public void Shoot()
    {
        if (Time.time > Atirar)
        {
            Atirar = Time.time + firerate;
            animator.SetTrigger("atirar");
            Instantiate(balaPrefab, FirePoint.position, FirePoint.rotation);
            //Destroy(balaPrefab, 2);
        }
    }
    private void Flip()
    {

        transform.Rotate(0f, 180f, 0f);
        m_FacingRight = !m_FacingRight;
//        sprite.flipX = !sprite.flipX;


    }

}
