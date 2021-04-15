using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Este script contiene las funciones que permiten desplegar un panel con la información de cada parte del automóvil.
 Autor: Luis Ignacio Ferro Salinas A01378248
 Última actualización: 12 de abril de 2021.
 */

public class MuestraBarrasCualidades : MonoBehaviour
{
    public void MuestraBarraParte(int parte) {
        this.transform.GetChild(parte).gameObject.SetActive(true);
    }

    public void ApagaBarraParte(int parte) {
        this.transform.GetChild(parte).gameObject.SetActive(false);
    }


    public void MuestraBarraCuerpo1() {
        MuestraBarraParte(4);
    }

    public void ApagaBarraCuerpo1() {
        ApagaBarraParte(4);
    }


    public void MuestraBarraCuerpo2()
    {
        MuestraBarraParte(5);
    }

    public void ApagaBarraCuerpo2()
    {
        ApagaBarraParte(5);
    }


    public void MuestraBarraCuerpo3()
    {
        MuestraBarraParte(6);
    }

    public void ApagaBarraCuerpo3()
    {
        ApagaBarraParte(6);
    }


    public void MuestraBarraLlantas1()
    {
        MuestraBarraParte(7);
    }

    public void ApagaBarraLlantas1()
    {
        ApagaBarraParte(7);
    }


    public void MuestraBarraLlantas2()
    {
        MuestraBarraParte(8);
    }

    public void ApagaBarraLlantas2()
    {
        ApagaBarraParte(8);
    }


    public void MuestraBarraLlantas3()
    {
        MuestraBarraParte(9);
    }

    public void ApagaBarraLlantas3()
    {
        ApagaBarraParte(9);
    }


    public void MuestraBarraFrenos1()
    {
        MuestraBarraParte(10);
    }

    public void ApagaBarraFrenos1()
    {
        ApagaBarraParte(10);
    }


    public void MuestraBarraFrenos2()
    {
        MuestraBarraParte(11);
    }

    public void ApagaBarraFrenos2()
    {
        ApagaBarraParte(11);
    }


    public void MuestraBarraFrenos3()
    {
        MuestraBarraParte(12);
    }

    public void ApagaBarraFrenos3()
    {
        ApagaBarraParte(12);
    }


    public void MuestraBarraSuspension1()
    {
        MuestraBarraParte(13);
    }

    public void ApagaBarraSuspension1()
    {
        ApagaBarraParte(13);
    }


    public void MuestraBarraSuspension2()
    {
        MuestraBarraParte(14);
    }

    public void ApagaBarraSuspension2()
    {
        ApagaBarraParte(14);
    }


    public void MuestraBarraSuspension3()
    {
        MuestraBarraParte(15);
    }

    public void ApagaBarraSuspension3()
    {
        ApagaBarraParte(15);
    }


    public void MuestraBarraChasis1()
    {
        MuestraBarraParte(16);
    }

    public void ApagaBarraChasis1()
    {
        ApagaBarraParte(16);
    }


    public void MuestraBarraChasis2()
    {
        MuestraBarraParte(17);
    }

    public void ApagaBarraChasis2()
    {
        ApagaBarraParte(17);
    }


    public void MuestraBarraChasis3()
    {
        MuestraBarraParte(18);
    }

    public void ApagaBarraChasis3()
    {
        ApagaBarraParte(18);
    }


    public void MuestraBarraMotor1()
    {
        MuestraBarraParte(19);
    }

    public void ApagaBarraMotor1()
    {
        ApagaBarraParte(19);
    }


    public void MuestraBarraMotor2()
    {
        MuestraBarraParte(20);
    }

    public void ApagaBarraMotor2()
    {
        ApagaBarraParte(20);
    }


    public void MuestraBarraMotor3()
    {
        MuestraBarraParte(21);
    }

    public void ApagaBarraMotor3()
    {
        ApagaBarraParte(21);
    }


    private void ApagaPanelesEstadisticas() {
        // Apago todos los paneles de estadisticas al iniciar la escena.
        ApagaBarraParte(4);
        ApagaBarraParte(5);
        ApagaBarraParte(6);
        ApagaBarraParte(7);
        ApagaBarraParte(8);
        ApagaBarraParte(9);
        ApagaBarraParte(10);
        ApagaBarraParte(11);
        ApagaBarraParte(12);
        ApagaBarraParte(13);
        ApagaBarraParte(14);
        ApagaBarraParte(15);
        ApagaBarraParte(16);
        ApagaBarraParte(17);
        ApagaBarraParte(18);
        ApagaBarraParte(19);
        ApagaBarraParte(20);
        ApagaBarraParte(21);
    }

    // Start is called before the first frame update
    void Start()
    {
        ApagaPanelesEstadisticas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
