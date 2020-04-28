using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{


    public Transform firePoint;
    public Transform chargedfirePoint;
    public GameObject balaPrefab;
    public GameObject chargedbala;
    public Animator animator;

   [SerializeField]

    //private SoundController sound;
    public AudioSource loopAudioSource;
    public AudioClip loopclip;
   // private AudioClip shootclip;
    private float pitchSpeed;
    public AudioClip shotclip;


    private bool charging = false;
    private float chargedTime;          // Tempo carregando 
    private float fireModeTime;


    private void Start()
    {

        charging = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (fireModeTime <= Time.time)
        {
            fireModeTime = 0f;
        }

        // Codigo de teste de tiro começa aqui
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charging = false;
            animator.SetTrigger("Atirando");
            
            loopAudioSource = gameObject.AddComponent<AudioSource>();
            loopAudioSource.clip = loopclip;
            loopAudioSource.loop = true;
            loopAudioSource.Play();
            
    
            Shoot();

        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (loopAudioSource.pitch < 1.5f)
            {
                loopAudioSource.pitch += pitchSpeed = Time.deltaTime;
            }


            if (charging == false)
            {

                charging = true;
                chargedTime = 0;
                

                
            }
            else
            {
                fireModeTime = Time.time + 0.5f;
                chargedTime += Time.deltaTime;

            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            charging = false;
            Destroy(loopAudioSource);

           // AudioSource.PlayClipAtPoint(shotclip, Camera.main.transform.position);// Funcionou sem esse

            if (chargedTime > 1.5f)
            {

                Instantiate(chargedbala, chargedfirePoint.position, chargedfirePoint.rotation);
                animator.SetTrigger("Atirando");

            }
        } 
        //codigo de teste tiro termina aqui

    }


    void Shoot ()
    {

        Instantiate(balaPrefab, firePoint.position, firePoint.rotation);



    }

}
        

