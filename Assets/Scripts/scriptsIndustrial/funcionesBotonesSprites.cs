using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
Script que hace que cambien los sprites del automovil cuando el usuario haga click entre las opciones, y modifica el presupuesto de forma consecuente.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 12 de abril 
*/

public class funcionesBotonesSprites : MonoBehaviour
{
    // El GameObject que contiene al automóvil que se muestra en pantalla.
    public GameObject automovil;

    // El chasis del automóvil necesario para saber cuál poner si cambia el cuerpo.
    private int spriteChasis = 12;

    // Creo una tabla de hash que se usa para calcular el presupuesto dependiendo de qué parte fue escogida.
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

    public struct BudgetAccess {
        int budget;
        bool access;
        public BudgetAccess(int budget, bool access) {
            this.budget = budget;
            this.access = access;
        }
    };

    private BudgetAccess UpdateBudget(string parteYSprite) {
        // Función para poder actualizar el valor del presupuesto que le queda al usuario para construir su auto dependiendo de las partes que son escogidas.

        // Actualizo las variables que componen el presupuesto.
        if (parteYSprite == "cuerpoSmart" || parteYSprite == "cuerpoChallenger" || parteYSprite == "cuerpoCybertruck")
        {
            GameManager.precioCuerpo = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "llantas1" || parteYSprite == "llantas2" || parteYSprite == "llantas3")
        {
            GameManager.precioLlantas = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "frenos1" || parteYSprite == "frenos2" || parteYSprite == "frenos3")
        {
            GameManager.precioFrenos = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "suspension1" || parteYSprite == "suspension2" || parteYSprite == "suspension3")
        {
            GameManager.precioSuspension = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "chasis1" || parteYSprite == "chasis2" || parteYSprite == "chasis3")
        {
            GameManager.precioChasis = (int)partesAPrecios[parteYSprite];
        } else if (parteYSprite == "motor1" || parteYSprite == "motor2" || parteYSprite == "motor3")
        {
            GameManager.precioMotor = (int)partesAPrecios[parteYSprite];
        }

        if (GameManager.precioCuerpo + GameManager.precioLlantas + GameManager.precioFrenos + GameManager.precioSuspension + GameManager.precioChasis + GameManager.precioMotor > 100) {
            return new BudgetAccess(GameManager.budget, false);
            // REVERTIR CAMBIO DE VARIABLE DE PRECIO. REVISAR EN LOS IFS Y REGRESAR FALSE QUITAR STRUCT

        }
        // Actualizo el presupuesto que le queda al usuario.
        GameManager.budget = 100 - (GameManager.precioCuerpo + GameManager.precioLlantas + GameManager.precioFrenos + GameManager.precioSuspension + GameManager.precioChasis + GameManager.precioMotor);
        // Actualizo el GameObject de texto que muestra el presupuesto.
        this.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Presupuesto: " + GameManager.budget.ToString() + "$";
        return new BudgetAccess(GameManager.budget, true); // regreso el presupuesto para revisar si todavía se puede cambiar;
    }

    // Funciones para cambiar todas las partes posibles del automóvil y actualizar el presupuesto.
    public void CambiaCuerpoSmart() {
        CambiaParte(0, 0);
        UpdateBudget("cuerpoSmart");
    }

    public void CambiaCuerpoChallenger() {
        CambiaParte(0, 1);
        UpdateBudget("cuerpoChallenger");
    }

    public void CambiaCuerpoCybertruck() {
        UpdateBudget("cuerpoCybertruck");
    }

    public void CambiaLlantas1() {
        CambiaParte(1, 0);
        UpdateBudget("llantas1");
    }

    public void CambiaLlantas2() {
        CambiaParte(1, 1);
        UpdateBudget("llantas2");
    }

    public void CambiaLlantas3() {
        CambiaParte(1, 2);
        UpdateBudget("llantas3");
    }

    public void CambiaFrenos1() {
        CambiaParte(2, 0);
        UpdateBudget("frenos1");
    }

    public void CambiaFrenos2()
    {
        CambiaParte(2, 1);
        UpdateBudget("frenos2");
    }

    public void CambiaFrenos3()
    {
        CambiaParte(2, 2);
        UpdateBudget("frenos3");
    }

    public void CambiaSuspensiones1() {
        CambiaParte(3, 0);
        UpdateBudget("suspension1");
    }

    public void CambiaSuspensiones2()
    {
        CambiaParte(3, 1);
        UpdateBudget("suspension2");
    }

    public void CambiaSuspensiones3()
    {
        CambiaParte(3, 2);
        UpdateBudget("suspension3");
    }

    public void CambiaChasis1() {
        CambiaParte(4, 0);
        spriteChasis = 12;
        UpdateBudget("chasis1");
    }

    public void CambiaChasis2()
    {
        CambiaParte(4, 1);
        spriteChasis = 13;
        UpdateBudget("chasis2");
    }

    public void CambiaChasis3()
    {
        CambiaParte(4, 2);
        spriteChasis = 14;
        UpdateBudget("chasis3");
    }

    public void CambiaChasis4()
    {
        CambiaParte(4, 3);
        spriteChasis = 15;
        UpdateBudget("chasis1");
    }

    public void CambiaChasis5()
    {
        CambiaParte(4, 4);
        spriteChasis = 16;
        UpdateBudget("chasis2");
    }

    public void CambiaChasis6()
    {
        CambiaParte(4, 5);
        spriteChasis = 17;
        UpdateBudget("chasis3");
    }

    public void CambiaChasis7()
    {
        CambiaParte(4, 6);
        spriteChasis = 18;
        UpdateBudget("chasis1");
    }

    public void CambiaChasis8()
    {
        CambiaParte(4, 7);
        spriteChasis = 19;
        UpdateBudget("chasis2");
    }

    public void CambiaChasis9()
    {
        CambiaParte(4, 8);
        spriteChasis = 20;
        UpdateBudget("chasis3");
    }

    public void CambiaMotor1() {
        CambiaParte(5, 6);
        UpdateBudget("motor1");
    }

    public void CambiaMotor2() {
        CambiaParte(5, 7);
        UpdateBudget("motor2");
    }

    public void CambiaMotor3()
    {
        CambiaParte(5, 8);
        UpdateBudget("motor3");
    }

    // Comienzo mostrando el presupuesto inicial.
    private void Start()
    {
        this.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Presupuesto: " + GameManager.budget.ToString() + "$";
    }

}


