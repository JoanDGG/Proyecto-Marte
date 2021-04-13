using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
Script que hace que cambien los sprites del automovil cuando el usuario haga click entre las opciones
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 8 de abril 
*/

public class funcionesBotonesSprites : MonoBehaviour
{
    // El GameObject que contiene al automóvil que se muestra en pantalla.
    public GameObject automovil;

    // El chasis del automóvil necesario para saber cuál poner si cambia el cuerpo.
    private int spriteChasis = 12;

    public void CambiaParte(int indiceParte, int indiceSprite) {
        // Función para cambiar todas las partes del automóvil, teniendo una opción de sprite seleccionada.

        // Para partes que solo se encuentran 1 vez en el auto (cuerpo, motor, chasis)
        if (indiceParte == 0 || (indiceParte >= 4 && indiceParte <= 5))
        {
            // Movemos las partes necesarias si el cuerpo se alarga.
            if (indiceParte == 0 && indiceSprite != 0) {
                // Llantas.
                automovil.transform.GetChild(1).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(1).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);

                // Frenos.
                automovil.transform.GetChild(2).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(2).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);

                // Suspensiones.
                automovil.transform.GetChild(3).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(3).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);

                // Motor.
                automovil.transform.GetChild(5).localPosition = new Vector3(3.2f, -0.8f, 0);

                // Chasis.
                if (indiceSprite == 1)
                {
                    automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(15 + (spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;
                }
                else {
                    automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(18 + (spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;
                }
            }
            else if (indiceParte == 0 && indiceSprite == 0){
                // Llantas.
                automovil.transform.GetChild(1).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(1).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);

                // Frenos.
                automovil.transform.GetChild(2).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(2).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);

                // Suspensiones.
                automovil.transform.GetChild(3).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(3).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);

                // Motor.
                automovil.transform.GetChild(5).localPosition = new Vector3(1.6f, -0.8f, 0);

                // Chasis.
                automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(12 + (spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;

            }

            // Cambio de sprite.
            automovil.transform.GetChild(indiceParte).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
        }
        else if (indiceParte >= 1 && indiceParte <= 3) {
            // Cambio de sprites.
            automovil.transform.GetChild(indiceParte).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
            automovil.transform.GetChild(indiceParte).GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
        }
    }

    private void UpdateBudget(string parteYSprite) {

        Hashtable partesAPrecios = new Hashtable()
        {
            {"cuerpoSmart", 21},
            {"cuerpoChallenger", 29},
            {"cuerpoCybertruck", 35},
            {"llantas1", 10},
            {"llantas2", 14},
            {"llantas3", 24},
            {"frenos1", 8},
            {"frenos2", 14},
            {"frenos3", 22},
            {"suspension1", 5},
            {"suspension2", 14},
            {"suspension3", 20},
            {"chasis1", 10},
            {"chasis2", 14},
            {"chasis3", 25},
            {"motor1", 8},
            {"motor2", 14},
            {"motor3", 20}
        };

    }

    // Funciones para cambiar todas las partes posibles del automóvil y actualizar el presupuesto.
    public void CambiaCuerpoSmart() {
        CambiaParte(0, 0);
        GameManager.budget -= 21;
    }

    public void CambiaCuerpoChallenger() {
        CambiaParte(0, 1);
        ;
    }

    public void CambiaCuerpoCybertruck() {
        CambiaParte(0, 2);
        GameManager.budget -= 35;
    }

    public void CambiaLlantas1() {
        CambiaParte(1, 0);
        GameManager.budget -= 10;
    }

    public void CambiaLlantas2() {
        CambiaParte(1, 1);
        GameManager.budget -= 14;
    }

    public void CambiaLlantas3() {
        CambiaParte(1, 2);
        GameManager.budget -= 24;
    }

    public void CambiaFrenos1() {
        CambiaParte(2, 0);
        GameManager
    }

    public void CambiaFrenos2()
    {
        CambiaParte(2, 1);
    }

    public void CambiaFrenos3()
    {
        CambiaParte(2, 2);
    }

    public void CambiaSuspensiones1() {
        CambiaParte(3, 0);
    }

    public void CambiaSuspensiones2()
    {
        CambiaParte(3, 1);
    }

    public void CambiaSuspensiones3()
    {
        CambiaParte(3, 2);
    }

    public void CambiaChasis1() {
        CambiaParte(4, 0);
        spriteChasis = 12;
    }

    public void CambiaChasis2()
    {
        CambiaParte(4, 1);
        spriteChasis = 13;
    }

    public void CambiaChasis3()
    {
        CambiaParte(4, 2);
        spriteChasis = 14;
    }

    public void CambiaChasis4()
    {
        CambiaParte(4, 3);
        spriteChasis = 15;
    }

    public void CambiaChasis5()
    {
        CambiaParte(4, 4);
        spriteChasis = 16;
    }

    public void CambiaChasis6()
    {
        CambiaParte(4, 5);
        spriteChasis = 17;
    }

    public void CambiaChasis7()
    {
        CambiaParte(4, 6);
        spriteChasis = 18;
    }

    public void CambiaChasis8()
    {
        CambiaParte(4, 7);
        spriteChasis = 19;
    }

    public void CambiaChasis9()
    {
        CambiaParte(4, 8);
        spriteChasis = 20;
    }

    public void CambiaMotor1() {
        CambiaParte(5, 6);
    }

    public void CambiaMotor2() {
        CambiaParte(5, 7);
    }

    public void CambiaMotor3()
    {
        CambiaParte(5, 8);
    }

}


