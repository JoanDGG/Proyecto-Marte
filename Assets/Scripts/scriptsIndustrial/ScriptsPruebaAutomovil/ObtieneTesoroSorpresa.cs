using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script para desactivar la plataforma que logra pasar hacia el tesoro sorpresa.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 22 de abril de 2021
*/

public class ObtieneTesoroSorpresa : MonoBehaviour
{

    public GameObject plataformaTesoro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(plataformaTesoro);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
