using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautaMenu : MonoBehaviour
{
    public float velocidadX = 7;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        sprRenderer.GetComponent<SpriteRenderer>();
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movHorizontal * velocidadX, rigidbody.velocity.y);
        if(rigidbody.velocity.x > 0.1){
            sprRenderer.flipX = false;
            print("se mueve");
        }
    }
}
