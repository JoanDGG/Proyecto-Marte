using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Este script sirve para darle movimiento al automóvil.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 19 de abril de 2021.
*/


public class MovimientoAutimovil : MonoBehaviour
{
    private float velocidadActualX;
    public float velocidadLimiteGas = 20f;
    public float fuerzaArranque;
    public float fuerzaFreno;
    public float reversa;
    private bool frenando = false;
    private bool reversando = false;
    private bool acelerando = false;
    private float signoOpuestoVelocidad;
    private void Update()
    {
        velocidadActualX = this.GetComponent<Rigidbody2D>().velocity.x;
        signoOpuestoVelocidad = velocidadActualX / Mathf.Abs(velocidadActualX);
        print(velocidadActualX);
        // Movimiento la derecha. (Gas)
        if (Input.GetAxis("Horizontal") > 0 && !reversando) {
            this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaArranque, 0));
            acelerando = true;
            frenando = false;
            reversando = false;
            // Límite superior de la velocidad.
            if (velocidadActualX > 20)
            {
                //this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-fuerzaArranque, 0));
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20f, 0f);
            }
        // Reversa
        } else if (Input.GetAxis("Horizontal") < 0 && !acelerando)
        {
            acelerando = false;
            reversando = true;
            frenando = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(reversa, 0f);

        // Movimiento a la izquierda. (Freno)
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaFreno * signoOpuestoVelocidad, 0f));
            acelerando = false;
            frenando = true;
            reversando = false;
            // Límite inferior del freno.
            if (velocidadActualX > -1 && velocidadActualX < 1)
            {
                //this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaArranque, 0));
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

            }
        }



        // Animaciones de girar las llantas. (Gas)
        if (velocidadActualX > 0 && !frenando)
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
            this.transform.GetChild(1).GetChild(1).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
        } else if (velocidadActualX < 0 && !frenando)
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
            this.transform.GetChild(1).GetChild(1).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
        }
    }

}
