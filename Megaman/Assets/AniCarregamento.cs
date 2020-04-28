using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCarregamento : MonoBehaviour
{

    public Animator carregando;
    // Start is called before the first frame update
    void Start()
    {
        carregando.SetBool("carregando", false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            carregando.SetBool("carregando", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            carregando.SetBool("carregando", false);

        }
    }
}
