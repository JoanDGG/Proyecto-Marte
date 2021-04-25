using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Este script sirve para darle movimiento al automóvil y su sonido al moverse.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 19 de abril de 2021.
*/


public class MovimientoAutimovil : MonoBehaviour
{
    // La velocidad actual en el eje x.
    private float velocidadActualX;


    // La velocidad límite del automóvil (motor).
    public float velocidadLimiteGas;

    // La fuerza del motor (motor);
    public float fuerzaMotor;

    // La velocidad de reversa (motor).
    public float reversa;


    // La fuerza que proporcionan los frenos (frenos).
    public float fuerzaFreno;

    // El material que proporcionan las llantas.
    public Material materialLlantas;

    // El boost que dan las llantas.
    public float boostLlantas;


    // Estados del automóvil.
    private bool frenando = false;
    private bool reversando = false;
    private bool acelerando = false;


    // El signo opuesto de la velocidad.
    private float signoOpuestoVelocidad;


    // Sonidos de motor de automóvil.
    public AudioSource sonidoArranque1;
    public AudioSource sonidoArranque2;
    public AudioSource sonidoArranque3;
    public AudioSource sonidoFinal1;
    public AudioSource sonidoFinal2;
    public AudioSource sonidoFinal3;


    // Sonido de automóvil en idle.
    public AudioSource sonidoIdle;


    // Sonido de freno.
    public AudioSource sonidoFreno;


    // Sonidos finales de motor.
    private AudioSource sonidoArranque;
    private AudioSource sonidoFinal;


    // Las imágenes para expresar si el jugador puede cambiar de velocidad.
    public Image imagenAcelera;
    public Image imagenFrena;
    public Image imagenReversa;


    // Los colores para indicar si puede cambiar de velocidad;
    public Color rojo;
    public Color verde;


    private void ApagaSonidosAutomovil()
    {
        // Función para apagar todos los sonidos del nivel relacionados con el automovil,
        sonidoArranque.Stop();
        sonidoFinal.Stop();
        sonidoIdle.Stop();
        sonidoFreno.Stop();
    }

    private void Start()
    {
        // Asigno el sonido correcto al movimiento del automóvil dependiendo del motor escogido en la escena anterior.
        if (GameManager.motor[1] == 6)
        {
            sonidoArranque = sonidoArranque1;
            sonidoFinal = sonidoFinal1;
        } else if(GameManager.motor[1] == 7) {
            sonidoArranque = sonidoArranque2;
            sonidoFinal = sonidoFinal2;
        } else if (GameManager.motor[1] == 8)
        {
            sonidoArranque = sonidoArranque3;
            sonidoFinal = sonidoFinal3;
        }

        // Sonido de idle al inicio.
        sonidoIdle.Play();

        // Siempre se puede frenar.
        imagenFrena.color = verde;
        imagenAcelera.color = verde;
        imagenReversa.color = verde;

        this.gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0.2f;
    }

    private void Update()
    {
        // Actualizo variables cada frame.
        velocidadActualX = this.GetComponent<Rigidbody2D>().velocity.x;
        signoOpuestoVelocidad = velocidadActualX / Mathf.Abs(velocidadActualX);
        //print(velocidadActualX);

        // Antes que nada el auto no se puede mover si las llantas no están tocando el suelo.
        if (GameManager.tocandoSueloLlantas)
        {
            // Movimiento la derecha. (Gas)
            if (Input.GetAxis("Horizontal") > 0 && (acelerando || (!reversando && Mathf.Abs(velocidadActualX) < 5)))
            {
                // Aplico el boost que dan los frenos en la aceleración.
                if (velocidadActualX < 5)
                {
                    this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(boostLlantas, 0));
                }

                // Prendo sonido adecuado.
                if (!sonidoArranque.isPlaying)
                {
                    ApagaSonidosAutomovil();
                    sonidoArranque.Play();
                }

                // La fuerza del motor.
                this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaMotor, 0));

                // Actualizo los estados.
                acelerando = true;
                frenando = false;
                reversando = false;

                // Límite superior de la velocidad.
                if (velocidadActualX > velocidadLimiteGas)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadLimiteGas, 0f);
                }
            }

            // Movimiento a la izquierda (reversa).
            else if (Input.GetAxis("Horizontal") < 0 && (reversando || (!acelerando && Mathf.Abs(velocidadActualX) < 5)))
            {
                // Actualizo los estados.
                acelerando = false;
                reversando = true;
                frenando = false;

                // En reversa y idle dejo el mismo sonido.
                if (!sonidoIdle.isPlaying)
                {
                    ApagaSonidosAutomovil();
                    sonidoIdle.Play();
                }

                // La velocidad de reversa.
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(reversa, 0f);
            }

            // Freno (llantas se detienen).
            else if (Input.GetAxis("Vertical") < 0)
            {

                // Prendo el sonido de los frenos.
                if (!sonidoFreno.isPlaying)
                {
                    ApagaSonidosAutomovil();
                    sonidoFreno.Play();
                }

                // Manejo la división entre 0 del signo opuesto de la velocidad.
                if (Mathf.Abs(velocidadActualX) > 0.1)
                {
                    // La fuerza de los frenos.
                    this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaFreno * signoOpuestoVelocidad, 0f));
                }

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

            // Usuario no entra en ningún estado anterior pero el auto se sigue moviendo.
            else if (Mathf.Abs(velocidadActualX) > 5)
            {
                // Usuario no presiona ningún botón de movimiento (idle)
                if (!sonidoIdle.isPlaying)
                {
                    ApagaSonidosAutomovil();
                    sonidoIdle.Play();
                }
                //print("Frena lo suficiente para cambiar de velocidad");
            }
            else
            {
                acelerando = false;
                frenando = false;
                reversando = false;

                // Usuario no presiona ningún botón de movimiento (idle)
                if (!sonidoIdle.isPlaying)
                {
                    ApagaSonidosAutomovil();
                    sonidoIdle.Play();
                }
                //print("idle");
            }
        }



        // Animaciones de girar las llantas. (Gas)
        if (!frenando || (frenando && Mathf.Abs(velocidadActualX) < 5))
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
            this.transform.GetChild(1).GetChild(1).GetComponent<Transform>().Rotate(0f, 0f, -velocidadActualX, Space.Self);
        }

        //print(velocidadActualX);
        // Convierto los colores de las imágenes.

        if (GameManager.tocandoSueloLlantas)
        {
            if (velocidadActualX > 5)
            {
                //print("no reversa");
                imagenReversa.color = rojo;
            }
            else if (velocidadActualX < -5)
            {
                //print("no acelera");
                imagenAcelera.color = rojo;
            }
            else
            {
                imagenAcelera.color = verde;
                imagenReversa.color = verde;
            }
        } else
        {
            imagenAcelera.color = rojo;
            imagenReversa.color = rojo;
            imagenFrena.color = rojo;
        }


    }

}
