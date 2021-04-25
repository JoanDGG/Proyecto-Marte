using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script para que se suelten los asteroides.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 24 de abril de 2021.
*/

public class SueltaAsteroides : MonoBehaviour
{

    // Las plataformas que sostienen las piedras.
    public GameObject plataforma1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Automovil"))
        {
            GameObject.Destroy(plataforma1, t: 0);
        }
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
