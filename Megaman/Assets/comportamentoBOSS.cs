using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comportamentoBOSS : MonoBehaviour
{
    [SerializeField]
    //Variaveis do Ataque 1
    GameObject Tiro;
    public Transform PontoTiro;
    float fireRate;
    float cooldown;
    int rand;
    public Animator animator;
    float time = 0;

    [SerializeField]
    //Variaveis do Ataque 2
    GameObject BlastATK;
    public Transform PontoBlast;




    public State state = State.INTRO;
    public float introDuration = 5.0f;

    public enum State  // enums are (very basically) integers with names.
    {
        INTRO,
        IDLE,
        ATTACK_1,
        BLAST,
        DEATH
    }

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.3f;
        cooldown = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Time.time > 5)
        {
            rand = Random.Range(0, 2);
            if (rand == 0)
            {

                animator.SetBool("Attack", false); // Fecha a boca para tiros provindos da cabeça
                TiroNormal();
            }

            else
            {
                animator.SetBool("Attack", true); // Abre a boca para rajada de tiro
                Blast();
            }
        }*/


        //Tentativa com StateMachineBehaviour
        time += Time.deltaTime;
        switch (state)
        {
            case State.INTRO: 
 
                if (time >= introDuration)
                {
                    state = State.ATTACK_1;
                    time -= introDuration;
                }
                break;
            case State.IDLE:

                if (time >= introDuration)
                {
                    rand = Random.Range(0, 2);
                    if (rand == 0)
                    {
                        state = State.ATTACK_1;
                    }


                    else
                    {
                        if(time >= 1 )
                        state = State.BLAST;

                    }

                    
                   // state = State.ATTACK_1;
                    time -= introDuration;
                    animator.SetBool("Attack", false); 
                    animator.SetBool("Fechar Boca", true);
                }
                break;

            case State.ATTACK_1://Ataque das bolinhas
                
                TiroNormal();
                animator.SetBool("Attack", false); 
                animator.SetBool("Fechar Boca", false);
                if (time >= introDuration)
                {
                    state = State.IDLE;
                    time -= introDuration;
                }
                break;
            case State.BLAST:
                animator.SetBool("Attack", true); // Abre a boca para rajada de tiro
                animator.SetBool("Fechar Boca", false);
                if (time >= introDuration)
                {
                    state = State.IDLE;
                    time -= introDuration;
                    animator.SetBool("Attack", false); 
                    animator.SetBool("Fechar Boca", true);
                    Blast();


                }

                break;
        }
    }

    public void TiroNormal()
    {
        if (Time.time > cooldown)
        {
            Instantiate(Tiro, PontoTiro.position, PontoTiro.rotation);
            cooldown = Time.time + fireRate;

        }
    }

    public void Blast()
    {
        Instantiate(BlastATK, PontoBlast.position, PontoBlast.rotation);;
        animator.SetBool("Attack", true);
    }


}
