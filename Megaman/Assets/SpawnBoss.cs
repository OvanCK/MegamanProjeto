using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    public Transform BossSpawn;
    
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(Boss, BossSpawn.position, BossSpawn.rotation);
        Destroy(gameObject);
    }

}
