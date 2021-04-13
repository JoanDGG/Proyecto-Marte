using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script maneja la animacion del personaje

Autor: Joan Daniel Guerrero Garcia
*/

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("velocity", Mathf.Abs(rb2D.velocity.x));

        if (!is_grounded_controller.is_grounded)
        {
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }
    }
}
