using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para actuar cuando el automóvil entra en el hielo.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 22 de abril de 2021.
*/

public class EntraHielo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Automovil"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0.2f;
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
