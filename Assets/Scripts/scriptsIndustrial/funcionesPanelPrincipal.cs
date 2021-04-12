using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Este script contiene las funciones que se asociarán con los botones del panel principal.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 2 de abril.
*/


public class funcionesPanelPrincipal : MonoBehaviour
{

    // El objeto de automovil para revisar cual cuerpo tiene.
    public GameObject automovil;

    public void ActivaBotonesSecundarios(int indiceBoton1, int indiceBoton2, int indiceBoton3) {
        // Función que recibe los índices de los 3 botones secundarios que se quieren activar en el panel, siempre hay 3 opciones de botones secundarios.
        this.transform.GetChild(1).GetChild(indiceBoton1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(indiceBoton2).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(indiceBoton3).gameObject.SetActive(true);
    }

    // funciones que muestran los sprites apropiados dependiendo de qué parte del auto escogieron.
    public void EscogeCuerpo()
    {
        ApagaTodos();
        ActivaBotonesSecundarios(0, 1, 2);
    }

    public void EscogeLlantas()
    {
        ApagaTodos();
        ActivaBotonesSecundarios(3, 4, 5);
    }

    public void EscogeFrenos()
    {
        ApagaTodos();
        ActivaBotonesSecundarios(6, 7, 8);
    }

    public void EscogeSuspension()
    {
        ApagaTodos();
        ActivaBotonesSecundarios(9, 10, 11);
    }

    public void EscogeChasis()
    {
        ApagaTodos();

        // En este caso es necesario revisar el nombre del sprite del cuerpo automovil porque el chasis depende del cuerpo.
        if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodySmart") {
            ActivaBotonesSecundarios(12, 13, 14);
        } else if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodyChallenger") {
            ActivaBotonesSecundarios(15, 16, 17);
        } else if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodyCybertruck") {
            ActivaBotonesSecundarios(18, 19, 20);
        }
    }

    public void EscogeMotor()
    {
        ApagaTodos();

        ActivaBotonesSecundarios(21, 22, 23);
    }

    private void ApagaTodos() {
        // Desactivar todos los botones secundarios al inicio del nivel, los que muestran las opciones de sprites.
        this.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(5).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(8).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(9).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(14).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(16).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(17).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(18).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(20).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(21).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(22).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(23).gameObject.SetActive(false);
    }

    private void Start()
    {
        // Desactivar todos los botones secundarios al inicio del nivel, los que muestran las opciones de sprites.
        ApagaTodos();
    }
}   
