using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
Script para mostrar al usuario el daño recibido por impactos de piedras y de caídas.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 23 de abril de 2021.
 */
public class MuestraDano : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetChild(1).GetComponent<Text>().text = GameManager.dano.ToString();
    }
}
