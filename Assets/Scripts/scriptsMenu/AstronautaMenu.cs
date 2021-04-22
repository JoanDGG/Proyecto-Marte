using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautaMenu : MonoBehaviour
{

    public float velocidadX = 5;
    public float velocidadY = 10; //Mov vert(salto)

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(movHorizontal * velocidadX, rigidbody.velocity.y);

        float movVertical = Input.GetAxis("Jump");      // [0, 1]
        if (movVertical > 0)
        {
            rigidbody.AddForce(Vector2.up * velocidadY);
        }
    }
}
