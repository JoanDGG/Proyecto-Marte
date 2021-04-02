using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Este script contiene las funciones que se asociarán con los botones del panel principal.
 Autor: Luis Ignacio Ferro Salinas A01378248
 Última actualización: 1 de abril.
 */


public class funcionesPanelPrincipal : MonoBehaviour
{

    // El objeto de automovil para revisar cual cuerpo tiene.

    public GameObject automovil;


    // funciones que muestran los sprites apropiados dependiendo de qué parte del auto escogieron.
    public void EscogeCuerpo()
    {
        ApagaTodos();
        this.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
    }

    public void EscogeLlantas()
    {
        ApagaTodos();
        this.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(5).gameObject.SetActive(true);
    }

    public void EscogeFrenos()
    {
        ApagaTodos();
        this.transform.GetChild(1).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
    }

    public void EscogeSuspension()
    {
        ApagaTodos();
        this.transform.GetChild(1).GetChild(9).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(11).gameObject.SetActive(true);
    }

    public void EscogeChasis()
    {
        ApagaTodos();

        if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodySmart") {
            this.transform.GetChild(1).GetChild(12).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(13).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(14).gameObject.SetActive(true);
        } else if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodyChallenger") {
            this.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(16).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(17).gameObject.SetActive(true);
        } else if (automovil.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "bodyCybertruck") {
            this.transform.GetChild(1).GetChild(18).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(19).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(20).gameObject.SetActive(true);
        }
    }

    public void EscogeMotor()
    {
        ApagaTodos();

        this.transform.GetChild(1).GetChild(21).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(22).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(23).gameObject.SetActive(true);
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
