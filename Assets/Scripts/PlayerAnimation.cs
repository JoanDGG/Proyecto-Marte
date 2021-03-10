using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("velocity", Mathf.Abs(rb2D.velocity.x));
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat("velocity", velocidad);

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
