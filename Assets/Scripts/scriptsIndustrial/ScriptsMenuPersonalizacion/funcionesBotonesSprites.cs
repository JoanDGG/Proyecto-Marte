using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
Script que hace que cambien los sprites del automovil cuando el usuario haga click entre las opciones y el sonido.
Además revisa que el cambio de pieza lo permita su presupuesto.
Finalmente exporta las funcionalidades de las partes.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 21 de abril 
*/

public class funcionesBotonesSprites : MonoBehaviour
{
    // El GameObject que contiene al automóvil que se muestra en pantalla.
    public GameObject automovil;

    // El chasis del automóvil necesario para saber cuál poner si cambia el cuerpo.
    public static int spriteChasis = 12;

    // Creo una tabla de hash para mapear las partes del auto con su precio.
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
    // El color rojo para cambiar a color rojo el presupuesto cuando no alcance el presupuesto;
    public Color rojo;

    public Color negro;

    // Referencia a un AudioSource para emitir el sonido de error cuando el usuario intenta cambiar una pieza y no le alcanza.
    public AudioSource sonidoWrong;

    // Referencia a un AudioSource para el sonido de cambio de parte.
    public AudioSource sonidoCambioParte;

    private void CambiaParte(int indiceParte, int indiceSprite) {
        // Función para cambiar todas las partes del automóvil, teniendo una opción de sprite seleccionada.

        // Se emite el sonido de cambio de parte.
        sonidoCambioParte.Play();

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

    private bool UpdateBudget(string parteYSprite) {
        // Si el presupuesto no se puede actualizar (no alcanza el dinero), regreso un false, si sí, lo actualizo.
        if (parteYSprite == "cuerpoSmart" || parteYSprite == "cuerpoChallenger" || parteYSprite == "cuerpoCybertruck")
        {
            if (GameManager.budget + GameManager.precioCuerpo - (int)partesAPrecios[parteYSprite] < 0) {
                return false;
            }

            GameManager.precioCuerpo = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "llantas1" || parteYSprite == "llantas2" || parteYSprite == "llantas3")
        {
            if (GameManager.budget + GameManager.precioLlantas - (int)partesAPrecios[parteYSprite] < 0)
            {
                return false;
            }
            GameManager.precioLlantas = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "frenos1" || parteYSprite == "frenos2" || parteYSprite == "frenos3")
        {
            if (GameManager.budget + GameManager.precioFrenos - (int)partesAPrecios[parteYSprite] < 0)
            {
                return false;
            }
            GameManager.precioFrenos = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "suspension1" || parteYSprite == "suspension2" || parteYSprite == "suspension3")
        {
            if (GameManager.budget + GameManager.precioSuspension - (int)partesAPrecios[parteYSprite] < 0)
            {
                return false;
            }
            GameManager.precioSuspension = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "chasis1" || parteYSprite == "chasis2" || parteYSprite == "chasis3")
        {
            if (GameManager.budget + GameManager.precioChasis - (int)partesAPrecios[parteYSprite] < 0)
            {
                return false;
            }
            GameManager.precioChasis = (int)partesAPrecios[parteYSprite];
        }
        else if (parteYSprite == "motor1" || parteYSprite == "motor2" || parteYSprite == "motor3")
        {
            if (GameManager.budget + GameManager.precioMotor - (int)partesAPrecios[parteYSprite] < 0)
            {
                return false;
            }
            GameManager.precioMotor = (int)partesAPrecios[parteYSprite];
        }

        // Actualizo el presupuesto que le queda al usuario.
        GameManager.budget = 100 - (GameManager.precioCuerpo + GameManager.precioLlantas + GameManager.precioFrenos + GameManager.precioSuspension + GameManager.precioChasis + GameManager.precioMotor);

        // Actualizo el GameObject de texto que muestra el presupuesto.
        this.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Presupuesto: " + GameManager.budget.ToString() + "$";
        return true;
    }


    private IEnumerator PresupuestoRojoEspera() {
        // Creo una corrutina para esperar 1 segundos.
        this.transform.GetChild(3).gameObject.GetComponent<Text>().color = rojo;

        sonidoWrong.Play();

        yield return new WaitForSeconds(1);

        this.transform.GetChild(3).gameObject.GetComponent<Text>().color = negro;

    }

    private void PresupuestoInvalido() {
        // Marco el presupuesto de rojo para expresar que no le alcanza al usuario cambiar de parte del automovil.

        StartCoroutine(PresupuestoRojoEspera());

    }

    // Funciones para cambiar todas las partes posibles del automóvil y actualizar el presupuesto.
    public void CambiaCuerpoSmart() {
        if (UpdateBudget("cuerpoSmart")) {
            CambiaParte(0, 0);
            GameManager.cuerpo[0] = 0;
            GameManager.cuerpo[1] = 0;
            GameManager.volumen = 65;
        } else {
            PresupuestoInvalido();
        }
    }

    public void CambiaCuerpoChallenger() {
        if (UpdateBudget("cuerpoChallenger"))
        {
            CambiaParte(0, 1);
            GameManager.cuerpo[0] = 0;
            GameManager.cuerpo[1] = 1;
            GameManager.volumen = 85;
        }
        else {
            PresupuestoInvalido();
        }
        
    }

    public void CambiaCuerpoCybertruck() {
        if (UpdateBudget("cuerpoCybertruck"))
        {
            CambiaParte(0, 2);
            GameManager.cuerpo[0] = 0;
            GameManager.cuerpo[1] = 2;
            GameManager.volumen = 100;
        }
        else {
            PresupuestoInvalido();
        }
    }

    public void CambiaLlantas1() {
        if (UpdateBudget("llantas1"))
        {
            CambiaParte(1, 0);
            GameManager.llantas[0] = 1;
            GameManager.llantas[1] = 0;
        }
        else {
            PresupuestoInvalido();
        }
    }

    public void CambiaLlantas2() {
        if (UpdateBudget("llantas2")) {
            CambiaParte(1, 1);
            GameManager.llantas[0] = 1;
            GameManager.llantas[1] = 1;
        } else {
            PresupuestoInvalido();
        }
        
    }

    public void CambiaLlantas3() {
        if (UpdateBudget("llantas3")) {
            CambiaParte(1, 2);
            GameManager.llantas[0] = 1;
            GameManager.llantas[1] = 2;
        }
        else {
            PresupuestoInvalido();
        }
    }

    public void CambiaFrenos1() {
        if (UpdateBudget("frenos1"))
        {
            CambiaParte(2, 0);
            GameManager.frenos[0] = 2;
            GameManager.frenos[1] = 0;
        } else
        {
            PresupuestoInvalido();
        }
        
    }

    public void CambiaFrenos2()
    {
        if (UpdateBudget("frenos2"))
        {
            CambiaParte(2, 1);
            GameManager.frenos[0] = 2;
            GameManager.frenos[1] = 1;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaFrenos3()
    {
        if (UpdateBudget("frenos3"))
        {
            CambiaParte(2, 2);
            GameManager.frenos[0] = 2;
            GameManager.frenos[1] = 2;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaSuspensiones1() {
        if (UpdateBudget("suspension1"))
        {
            CambiaParte(3, 0);
            GameManager.suspensiones[0] = 3;
            GameManager.suspensiones[1] = 0;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaSuspensiones2()
    {
        if (UpdateBudget("suspension2"))
        {
            CambiaParte(3, 1);
            GameManager.suspensiones[0] = 3;
            GameManager.suspensiones[1] = 1;
        } else {
            PresupuestoInvalido();
        }
    }

    public void CambiaSuspensiones3()
    {
        if (UpdateBudget("suspension3"))
        {
            CambiaParte(3, 2);
            GameManager.suspensiones[0] = 3;
            GameManager.suspensiones[1] = 2;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis1() {
        if (UpdateBudget("chasis1"))
        {
            CambiaParte(4, 0);
            spriteChasis = 12;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 0;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis2()
    {
        if (UpdateBudget("chasis2"))
        {
            CambiaParte(4, 1);
            spriteChasis = 13;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 1;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis3()
    {
        if (UpdateBudget("chasis3"))
        {
            CambiaParte(4, 2);
            spriteChasis = 14;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 2;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis4()
    {
        if (UpdateBudget("chasis1"))
        {
            CambiaParte(4, 3);
            spriteChasis = 15;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 3;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis5()
    {
        if (UpdateBudget("chasis2"))
        {
            CambiaParte(4, 4);
            spriteChasis = 16;
            GameManager.cuerpo[0] = 4;
            GameManager.cuerpo[1] = 4;
        } else {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis6()
    {
        if (UpdateBudget("chasis3"))
        {
            CambiaParte(4, 5);
            spriteChasis = 17;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 5;
        } else {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis7()
    {
        if (UpdateBudget("chasis1")) {
            CambiaParte(4, 6);
            spriteChasis = 18;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 6;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis8()
    {
        if (UpdateBudget("chasis2"))
        {
            CambiaParte(4, 7);
            spriteChasis = 19;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 7;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaChasis9()
    {
        if (UpdateBudget("chasis3"))
        {
            CambiaParte(4, 8);
            spriteChasis = 20;
            GameManager.chasis[0] = 4;
            GameManager.chasis[1] = 8;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaMotor1() {
        if (UpdateBudget("motor1"))
        {
            CambiaParte(5, 6);
            GameManager.motor[0] = 5;
            GameManager.motor[1] = 6;
        } else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaMotor2() {
        if (UpdateBudget("motor2"))
        {
            CambiaParte(5, 7);
            GameManager.motor[0] = 5;
            GameManager.motor[1] = 7;
        }
        else
        {
            PresupuestoInvalido();
        }
    }

    public void CambiaMotor3()
    {
        if (UpdateBudget("motor3"))
        {
            CambiaParte(5, 8);
            GameManager.motor[0] = 5;
            GameManager.motor[1] = 8;
        } else
        {
            PresupuestoInvalido();
        }
    }

    // Comienzo mostrando el presupuesto inicial.
    private void Start()
    {
        this.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Presupuesto: " + GameManager.budget.ToString() + "$";
    }
}


