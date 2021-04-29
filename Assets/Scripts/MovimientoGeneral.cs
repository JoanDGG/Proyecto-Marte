using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoGeneral : MonoBehaviour
{

    public float velocidad = 7;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameManager.nivelGlobal = 0;
        GameManager.tiempoLogOut = System.DateTime.Now;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(movHorizontal * velocidad, movVertical * velocidad);
        float ABSvelocidad = Mathf.Abs((rigidbody.velocity.x + rigidbody.velocity.y));
        anim.SetFloat("velocidad", ABSvelocidad);
        if (rigidbody.velocity.x > 0.1)
        {
            sprRenderer.flipX = false;
        }
        else if (rigidbody.velocity.x < -0.1)
        {
            sprRenderer.flipX = true;
        }
    }
}
