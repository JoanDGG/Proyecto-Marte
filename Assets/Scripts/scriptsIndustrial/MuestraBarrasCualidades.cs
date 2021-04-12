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
        MuestraBarraParte(3);
    }

    public void ApagaBarraCuerpo1() {
        ApagaBarraParte(3);
    }

    public void MuestraBarraCuerpo2()
    {
        MuestraBarraParte(4);
    }

    public void ApagaBarraCuerpo2()
    {
        ApagaBarraParte(4);
    }
    public void MuestraBarraCuerpo3()
    {
        MuestraBarraParte(5);
    }

    public void ApagaBarraCuerpo3()
    {
        ApagaBarraParte(5);
    }

    private void ApagaPanelesEstadisticas() {
        // Apago todos los paneles de estadisticas al iniciar la escena.
        ApagaBarraParte(3);
        ApagaBarraParte(4);
        ApagaBarraParte(5);
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
