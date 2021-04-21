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
    // La velocidad actual en el eje x.
    private float velocidadActualX;

    // La velocidad límite del automóvil (motor).
    public float velocidadLimiteGas = 20f;

    // La fuerza del motor (motor);
    public float fuerzaMotor;

    // El boost que da la fricción de las llantas (llantas).
    public float bonusLlantas;

    // La fuerza que proporcionan los frenos (frenos).
    public float fuerzaFreno;

    // La velocidad de reversa (motor).
    public float reversa;

    // Estados del automóvil.
    private bool frenando = false;
    private bool reversando = false;
    private bool acelerando = false;

    // El signo opuesto de la velocidad.
    private float signoOpuestoVelocidad;

    private void Update()
    {
        // Actualizo variables cada frame.
        velocidadActualX = this.GetComponent<Rigidbody2D>().velocity.x;
        signoOpuestoVelocidad = velocidadActualX / Mathf.Abs(velocidadActualX);
        print(velocidadActualX);

        // Movimiento la derecha. (Gas)
        if (Input.GetAxis("Horizontal") > 0 && (acelerando || (!reversando && Mathf.Abs(velocidadActualX) < 5)))
        {
            // La fuerza del motor.
            this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaMotor, 0));

            // Actualizo los estados.
            acelerando = true;
            frenando = false;
            reversando = false;

            // Límite superior de la velocidad.
            if (velocidadActualX > 20)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20f, 0f);
            }
        }

        // Movimiento a la izquierda (reversa).
        else if (Input.GetAxis("Horizontal") < 0 && (reversando || (!acelerando && Mathf.Abs(velocidadActualX) < 5)))
        {
            // Actualizo los estados.
            acelerando = false;
            reversando = true;
            frenando = false;

            // La velocidad de reversa.
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(reversa, 0f);
        }

        // Freno (llantas se detienen).
        else if (Input.GetAxis("Vertical") < 0)
        {
            // La fuerza de los frenos.
            this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaFreno * signoOpuestoVelocidad, 0f));

            // Actualizo los estados.
            acelerando = false;
            reversando = false;
            frenando = true;

            // Límite inferior del freno.
            if (velocidadActualX > -1 && velocidadActualX < 1)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }

        // Cuando el usuario no frena lo suficiente para cambiar de velocidad.
        else if (Mathf.Abs(velocidadActualX) > 5)
        {
            print("Frena lo suficiente para cambiar de velocidad");
        }



        // Animaciones de girar las llantas. (Gas)
        if (!frenando || (frenando && Mathf.Abs(velocidadActualX) < 5))
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
            this.transform.GetChild(1).GetChild(1).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
        }
    }

}
