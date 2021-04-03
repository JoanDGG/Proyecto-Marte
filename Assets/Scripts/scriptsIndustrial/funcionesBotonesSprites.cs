using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 Script que hace que cambien los sprites del automovil cuando el usuario haga click entre las opciones
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 2 de abril 
 */

public class funcionesBotonesSprites : MonoBehaviour
{

    // El GameObject que contiene al automóvil que se muestra en pantalla.
    public GameObject automovil;

    public void CambiaParte(int indiceParte, int indiceSprite) {
        // Función para cambiar todas las partes del automóvil, teniendo una opción de sprite seleccionada.

        // Para partes que solo se encuentran 1 vez en el auto (cuerpo, motor, chasis)
        if (indiceParte == 0 || (indiceParte >= 4 && indiceParte <= 5))
        {
            // Movemos las partes necesarias si el cuerpo se alarga
            if (indiceParte == 0 && indiceSprite != 0) {
                automovil.transform.GetChild(1).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(1).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);

                automovil.transform.GetChild(2).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(2).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);

                automovil.transform.GetChild(3).GetChild(0).localPosition = new Vector3(2.4f, -1.6f, 0);
                automovil.transform.GetChild(3).GetChild(1).localPosition = new Vector3(-2.4f, -1.6f, 0);
            }
            else if (indiceParte == 0 && indiceSprite == 0){
                automovil.transform.GetChild(1).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(1).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);

                automovil.transform.GetChild(2).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(2).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);

                automovil.transform.GetChild(3).GetChild(0).localPosition = new Vector3(1.6f, -1.6f, 0);
                automovil.transform.GetChild(3).GetChild(1).localPosition = new Vector3(-1.6f, -1.6f, 0);
            }

            // Cambio de sprite.
            automovil.transform.GetChild(indiceParte).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
        }
        else if (indiceParte >= 1 && indiceParte <= 3) {
            // Cambio de sprites.
            automovil.transform.GetChild(indiceParte).GetChild(0).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).GetComponent<Image>().sprite;
            automovil.transform.GetChild(indiceParte).GetChild(1).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).GetComponent<Image>().sprite;
        }
    }


    // Funciones para cambiar todas las partes posibles del automóvil
    public void CambiaCuerpoSmart() {
        CambiaParte(0, 0);
    }

    public void CambiaCuerpoChallenger() {
        CambiaParte(0, 1);
    }

    public void CambiaCuerpoCybertruck() {
        CambiaParte(0, 2);
    }

    public void CambiaLlantas1() {
        CambiaParte(1, 0);
    }

    public void CambiaLlantas2() {
        CambiaParte(1, 1);
    }

    public void CambiaLlantas3() {
        CambiaParte(1, 2);
    }

    public void CambiaFrenos1() {
        CambiaParte(2, 0);
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
    }

    public void CambiaChasis2()
    {
        CambiaParte(4, 1);
    }

    public void CambiaChasis3()
    {
        CambiaParte(4, 2);
    }

    public void CambiaChasis4()
    {
        CambiaParte(4, 3);
    }

    public void CambiaChasis5()
    {
        CambiaParte(4, 4);
    }

    public void CambiaChasis6()
    {
        CambiaParte(4, 5);
    }

    public void CambiaChasis7()
    {
        CambiaParte(4, 6);
    }

    public void CambiaChasis8()
    {
        CambiaParte(4, 7);
    }

    public void CambiaChasis9()
    {
        CambiaParte(4, 8);
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


