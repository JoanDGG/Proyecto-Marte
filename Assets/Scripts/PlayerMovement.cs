using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private bool facingRight = true;
    private bool movingRight = false;
    private bool movingLeft = false;
    public int time = 120;
    private int original_time;

    private bool is_attacking = false;

    private bool first_attack = true;

    public float movementSpeed = 5;
    public float jumpValue = 8;

    public float movementValue;
    private float movVertical;

    Vector2 velocity;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        original_time = time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump(jumpValue);
        }

        if (Input.GetMouseButtonDown(0) || is_attacking)
        {
            if (first_attack)
            {
                animator.SetBool("attacking", true);
                //Debug.Log("Ataque 1");
                first_attack = false;
            }
            else
            {
                animator.SetBool("attacking2", true);
                //Debug.Log("Ataque 2");
                first_attack = true;
            }
        }
        else
        {
            if (!first_attack)
            {
                animator.SetBool("attacking", false);
            }
            else
            {
                animator.SetBool("attacking2", false);
            }
        }

        if(is_attacking)
        {
            is_attacking = false;
        }
        movementValue = Input.GetAxis("Horizontal");
        movVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(movementValue * movementSpeed, rigidbody2d.velocity.y);

        if ((movementValue > 0.0f && !facingRight) || (movementValue < 0.0f && facingRight))
        {
            Flip();
        }

        if (movingRight)
        {
            if (time > 0)
            {
                rigidbody2d.velocity = new Vector2(movementSpeed, rigidbody2d.velocity.y);
                --time;
            }
            if (!facingRight)
            {
                Flip();
            }
            
        }
        if (movingLeft)
        {
            if (time > 0)
            {
                rigidbody2d.velocity = new Vector2(-movementSpeed, rigidbody2d.velocity.y);
                --time;
            }
            if (facingRight)
            {
                Flip();
            }
        }
        if (time <= 0)
        {
            Release();
            time = original_time;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    public void MoveRight(int duration)
    {
        movingRight = true;
        time = duration;
        //Debug.Log("Moving Right");
        //Debug.Log(time);
        //return true;
    }

    public void MoveLeft(int duration)
    {
        movingLeft = true;
        time = duration;
        //Debug.Log("Moving Left");
        //Debug.Log(time);
        //return true;
    }

    public void Attack()
    {
        is_attacking = true;
    }

    public void Jump(float force)
    {
        if (is_grounded_controller.is_grounded)
        {
            rigidbody2d.AddForce(Vector3.up * force, ForceMode2D.Impulse);
        }
        //Debug.Log("Jump");
        //Debug.Log(force);
    }

    public void Release()
    {
        //Debug.Log("Stop");
        movingLeft = false;
        movingRight = false;
    }
}
