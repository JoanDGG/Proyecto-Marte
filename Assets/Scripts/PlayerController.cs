using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public bool moveleft;
    public bool moveright;
    public Rigidbody2D rb;
    private float movedirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InputHandler()
    {
        movedirection = Input.GetAxisRaw("Horizontal");
    }

    public void TouchMove(float movedirection)
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f && moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        else if (Mathf.Abs(rb.velocity.y) < 0.01f && moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
    }

}