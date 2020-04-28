using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum Direction {LEFT,RIGHT}
public class MovPlayer : MonoBehaviour {


    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public float speed = 5.0f;
    public bool isOnGround = false;
    public float jumpPower = 2.0f;
    private bool m_FacingRight = true;
    private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround; 
    private Vector3 m_Velocity = Vector3.zero;

    public Animator animator;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SoundController sound;



    const float k_GroundedRadius = .2f;
    private Direction playerDirection = Direction.RIGHT;

    bool jump = false;

    public UnityEvent OnLandEvent;



    public Direction PlayerDirection{
        get         {
            return playerDirection;
        }
    }

    void Start()
    {
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        sound = GameObject.Find("Sons").GetComponent<SoundController>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

        void MovePlayer()
    {
        float hMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //   _transform.Translate(hMove, 0, 0);
        Vector3 targetVelocity = new Vector2(hMove * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


       

        animator.SetFloat("Andar", Mathf.Abs(hMove));

        if (hMove > 0 && !m_FacingRight)
        {
          //  playerDirection = Direction.RIGHT;
            Flip();

        }
        else if (hMove < 0 && m_FacingRight)
        {
         //   playerDirection = Direction.LEFT;
            Flip();

        }

    }
    public void schedulePlay(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }
    void Jump()
    {
            if((Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true) || (Input.GetKeyDown(KeyCode.W)&& isOnGround == true))
        {
            isOnGround = false;
            jump = true;
            schedulePlay(sound.mm_jump);
            //teste.play
            _rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Pulo", true);

        }
    }

    void OnCollisionEnter2D()
{
    isOnGround = true;
    animator.SetBool("Pulo", false);
    }
    void OnCollisionexit2D()
{
    isOnGround = false;
    animator.SetBool("Pulo", true);


    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;


       transform.Rotate(0f, 180f, 0f);


    }

    public void OnLanding()
    {
        animator.SetBool("Pulo", false);
    }


}

    