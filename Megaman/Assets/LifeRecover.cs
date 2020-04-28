using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRecover : MonoBehaviour
{
    VidaJogador HP;
    public GameObject Player;

    public int HPRec = 25; //Quantia de Vida recuperada
    private SoundController sound;
   // public AudioSource sound;


    private void Start()
    {
        sound = GameObject.Find("Sons").GetComponent<SoundController>();


    }

    private void Awake()
    {
        HP = FindObjectOfType<VidaJogador>();

    }

    void OnTriggerEnter2D(Collider2D tocar)
    {

        if (tocar.CompareTag("Player"))
        {
        VidaJogador vidaJogador = tocar.GetComponent<VidaJogador>();
        HP.health += HPRec;
        schedulePlay(sound.mm_item);
        Destroy(gameObject);
    }

    }
    public void schedulePlay(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }



}
