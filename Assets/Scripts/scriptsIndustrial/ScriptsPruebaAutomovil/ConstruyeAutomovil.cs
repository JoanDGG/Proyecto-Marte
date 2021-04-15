using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Script para construir el automóvil igual que como estaba en el menu.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 15 de abril de 2021.
*/

public class ConstruyeAutomovil : MonoBehaviour
{
    public GameObject automovil;

    // Copio función para reconstruir auto elegido en el menú en esta escena.
    public void CambiaParte(int indiceParte, int indiceSprite)
    {
        // Función para cambiar todas las partes del automóvil, teniendo una opción de sprite seleccionada.

        // Para partes que solo se encuentran 1 vez en el auto (cuerpo, motor, chasis)
        if (indiceParte == 0 || (indiceParte >= 4 && indiceParte <= 5))
        {
            // Movemos las partes necesarias si el cuerpo se alarga.
            if (indiceParte == 0 && indiceSprite != 0)
            {
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
                    automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(15 + (funcionesBotonesSprites.spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;
                }
                else
                {
                    automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(18 + (funcionesBotonesSprites.spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;
                }
            }
            else if (indiceParte == 0 && indiceSprite == 0)
            {
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
                automovil.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(12 + (funcionesBotonesSprites.spriteChasis % 3)).gameObject.GetComponent<Image>().sprite;

            }

            // Cambio de sprite.
            automovil.transform.GetChild(indiceParte).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
        }
        else if (indiceParte >= 1 && indiceParte <= 3)
        {
            // Cambio de sprites.
            automovil.transform.GetChild(indiceParte).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
            automovil.transform.GetChild(indiceParte).GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(1).GetChild(indiceParte * 3 + indiceSprite).gameObject.GetComponent<Image>().sprite;
        }
    }

    // Cambio las partes del automovil.
    /*
    CambiaParte(GameManager.cuerpo[0], GameManager.cuerpo[1]);
    CambiaParte(GameManager.llantas[0], GameManager.llantas[1]);
    CambiaParte(GameManager.frenos[0], GameManager.frenos[1]);
    CambiaParte(GameManager.suspension[0], GameManager.suspension[1]);
    CambiaParte(GameManager.chasis[0], GameManager.chasis[1]);
    CambiaParte(GameManager.motor[0], GameManager.motor[1]);
    */


}
