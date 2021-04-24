using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonajeResena : MonoBehaviour
{
    public Transform transform;
    public GameObject resena;
    private Vector3 posicion = new Vector3(-7, -8, 0);
    private Vector3 posicionFinal = new Vector3(15, -8, 0);
    private Rigidbody2D rb2D;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocidad", Mathf.Abs(rb2D.velocity.x));
        if (!resena.GetComponent<Resena>().continuar)
        {
            if(transform.position.x < posicion.x)
            {
                rb2D.velocity = (posicion - transform.position).normalized * 2;
            }
            else
            {
                rb2D.velocity = new Vector3(0, 0, 0);
            }

        }
        else
        {
            if (transform.position.x < posicionFinal.x)
            {
                rb2D.velocity = (posicionFinal - transform.position).normalized * 6;
            }
            else
            {
                rb2D.velocity = new Vector3(0, 0, 0);
                //Termina la escena

            }
        }
    }
}
