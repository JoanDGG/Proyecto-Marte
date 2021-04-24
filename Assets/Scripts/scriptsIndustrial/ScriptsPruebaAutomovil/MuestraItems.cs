using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
Script para mostrar el número recolectado de items.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 23 de abril de 2021.
*/

public class MuestraItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = GameManager.itemsRecolectados.ToString();
    }
}
