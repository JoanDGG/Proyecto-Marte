using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script para que se suelten los asteroides.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 23 de abril de 2021.
*/

public class SueltaAsteroides : MonoBehaviour
{

    // Las plataformas que sostienen las piedras.
    public GameObject plataforma1;
    public GameObject plataforma2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Automovil"))
        {
            GameObject.Destroy(plataforma1, t: 0);
            GameObject.Destroy(plataforma2, t: 0);
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
