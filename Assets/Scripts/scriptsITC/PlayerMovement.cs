using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public bool facingRight = true;
    private bool movingRight = false;
    private bool movingLeft = false;
    public int time = 120;
    private int original_time;

    private bool is_attacking = false;
    private bool fire_active = false;

    private bool first_attack = true;

    public float movementSpeed = 5;
    public float jumpValue = 8;

    public float inputMove;
    public bool inputJump;
    public bool inputFire;
    public bool inputAttack;

    Vector2 velocity;
    private Animator animator;
    public AudioSource Caminar;
    public AudioSource Llave;
    public AudioSource Extintor;

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
        if (!Game_Controller.is_editing)
        {
            inputMove = Input.GetAxis("Horizontal");
            inputJump = Input.GetButtonDown("Jump");
            inputAttack = Input.GetMouseButtonDown(0);
            inputFire = Input.GetMouseButtonDown(1);
        }

        if (inputJump)
        {
            Jump(jumpValue);
        }

        if (rigidbody2d.velocity.y > 0.1)
        {
            gameObject.layer = 7;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            gameObject.layer = 6;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (inputFire || fire_active)
        {
            Extintor.Play();
            animator.SetBool("extintor", true);
            //Debug.Log("Apagando fuego...");
        }
        else
        {
            animator.SetBool("extintor", false);
        }

        if (inputAttack || is_attacking)
        {
            if (is_grounded_controller.is_grounded)
            {
                Llave.Play();
            }

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

        if (is_attacking || fire_active)
        {
            is_attacking = false;
            fire_active = false;
        }

        if((inputMove != 0 || movingLeft || movingRight) && (is_grounded_controller.is_grounded))
        {
            Caminar.enabled = true;
        }
        else
        {
            Caminar.enabled = false;
        }
    }

    void FixedUpdate()
    {

        rigidbody2d.velocity = new Vector2(inputMove * movementSpeed, rigidbody2d.velocity.y);

        if ((inputMove > 0.0f && !facingRight) || (inputMove < 0.0f && facingRight))
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
    }

    public void MoveLeft(int duration)
    {
        movingLeft = true;
        time = duration;
        //Debug.Log("Moving Left");
        //Debug.Log(time);
    }

    public void Attack()
    {
        is_attacking = true;
    }

    public void Fire()
    {
        fire_active = true;
        //Debug.Log("Turning off Fire");
    }

    public void Jump(float force)
    {
        if (is_grounded_controller.is_grounded)
        {
            rigidbody2d.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            //Debug.Log("Jump");
            //Debug.Log(force);
        }
    }

    public void Release()
    {
        movingLeft = false;
        movingRight = false;
        //Debug.Log("Stop");
    }
}
