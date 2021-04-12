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
    public void MuestraBarraCuerpo1() {
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
    }

    public void ApagaBarraCuerpo1() {
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);

    }

    private void ApagaPanelesEstadisticas() {
        // Apago todos los paneles de estadisticas al iniciar la escena.
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
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
